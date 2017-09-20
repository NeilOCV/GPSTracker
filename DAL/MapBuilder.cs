using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public enum MapType
    {
        PollyLinesOnly = 10,
        PollyLinesAndAllMarkers = 20,
        PollyLinesAndLastMarker = 30,
        AllMarkersOnly = 40
    }
    
    public class MapBuilder
    {
        private string MakeLine(string strLine)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(strLine);
            builder.Append(Environment.NewLine);

            return builder.ToString();
        }
        private string AddAllMarkers(List<DisplayItems> lst)
        {
            StringBuilder builder = new StringBuilder();

            Int32 intCounter = 1;
            foreach(DisplayItems marker in lst)
            {
                builder.Append("['" + marker.device + "'," + marker.latitude.ToString() + "," + marker.longitude.ToString() + "," + intCounter.ToString() + "]");
                if (intCounter<lst.Count)
                    builder.Append(",");
                builder.Append(Environment.NewLine);
                intCounter++;
            }

            return builder.ToString();
        }
        private string MapWithMarkersOnly()
        {
            List<DisplayItems> lst = new List<DisplayItems>();
            EDM edm = new EDM();
            var prog = from tb in edm.GetLastOfEach()
                       select new DisplayItems
                       {
                           device_id = (int)tb.device_id,
                           log_date_time = tb.date_time.ToString(),
                           location_provider = tb.provider,
                           battery = (int)tb.battery,
                           device = tb.device_name,
                           latitude = (decimal)tb.latitude,
                           longitude = (decimal)tb.longitude
                       };
            lst = prog.ToList();
            
            
            StringBuilder builder = new StringBuilder();

            builder.Append(MakeLine("<script src=\"http://maps.google.com/maps/api/js?sensor=false\"></script>"));
            builder.Append(MakeLine("<script src=\"http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.1.min.js\"></script>"));

            builder.Append(MakeLine("<script type=\"text/javascript\">"));
            builder.Append(MakeLine("var locations = ["));
            builder.Append(MakeLine(AddAllMarkers(lst)));
            builder.Append(MakeLine("];"));
            builder.Append(MakeLine("var map = new google.maps.Map(document.getElementById('map'), {"));
            builder.Append(MakeLine("zoom: 5,"));
            builder.Append(MakeLine("center: new google.maps.LatLng(51.530616, -0.123125),"));
            builder.Append(MakeLine("mapTypeId: google.maps.MapTypeId.ROADMAP"));
            builder.Append(MakeLine("});"));

            builder.Append(MakeLine("var infowindow = new google.maps.InfoWindow();"));
            builder.Append(MakeLine("var marker, i;"));
            builder.Append(MakeLine("var markers = new Array();"));
            builder.Append(MakeLine("for (i = 0; i < locations.length; i++) {  "));
            builder.Append(MakeLine("marker = new google.maps.Marker({"));
            builder.Append(MakeLine("position: new google.maps.LatLng(locations[i][1], locations[i][2]),"));
            builder.Append(MakeLine("map: map"));
            builder.Append(MakeLine("});"));
            builder.Append(MakeLine("markers.push(marker);"));
            builder.Append(MakeLine("google.maps.event.addListener(marker, 'click', (function(marker, i) {"));
            builder.Append(MakeLine("return function() {"));
            builder.Append(MakeLine("infowindow.setContent(locations[i][0]);"));
            builder.Append(MakeLine("infowindow.open(map, marker);"));
            builder.Append(MakeLine("}"));
            builder.Append(MakeLine("})(marker, i));"));
            builder.Append(MakeLine("}"));
            builder.Append(MakeLine("function AutoCenter() {"));
            builder.Append(MakeLine("//  Create a new viewpoint bound"));
            builder.Append(MakeLine("var bounds = new google.maps.LatLngBounds();"));
            builder.Append(MakeLine("//  Go through each..."));
            builder.Append(MakeLine("$.each(markers, function (index, marker) {"));
            builder.Append(MakeLine("bounds.extend(marker.position);"));
            builder.Append(MakeLine("});"));
            builder.Append(MakeLine("//  Fit these bounds to the map"));
            builder.Append(MakeLine("map.fitBounds(bounds);"));
            builder.Append(MakeLine("}"));
            builder.Append(MakeLine("AutoCenter();"));
            builder.Append(MakeLine("</script>"));

            return builder.ToString();
        }
        public string BuildMap(MapType mapType, DateTime dtMapHistoryDate = new DateTime())
        {
            StringBuilder builder = new StringBuilder();

            switch (mapType)
            {
                case MapType.PollyLinesOnly:
                    { }
                    break;
                case MapType.PollyLinesAndAllMarkers:
                    { }
                    break;
                case MapType.PollyLinesAndLastMarker:
                    { }
                    break;
                case MapType.AllMarkersOnly:
                    { return MapWithMarkersOnly(); }
                    break;
                default:
                    { }
                    break;
            }

            return builder.ToString();
        }
    }
}

namespace BusTrackingSimulator.Services
{
    using System;
    using BusTrackingSimulator.Models;
    using BusTrackingSimulator.Services.Contracts;

    public class BusTrackerService : IBusTrackerService
    {
        private List<Bus> Buses;
        private Random random = new Random();

        //        private const string GpxData1 =
        //"""
        //<?xml version="1.0" encoding="UTF-8" standalone="no" ?>
        //<gpx version="1.1" creator="http://www.geoplaner.com" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.topografix.com/GPX/1/1" xsi:schemaLocation="http://www.topografix.com/GPX/1/1 http://www.topografix.com/GPX/1/1/gpx.xsd">
        //<rte>
        //<name>Route2</name>
        //<rtept lat="18.47591" lon="-69.90858">
        //<name>WP01-A</name>
        //</rtept>
        //<rtept lat="18.47599" lon="-69.90965">
        //<name>WP02-B</name>
        //</rtept>
        //<rtept lat="18.47619" lon="-69.9104">
        //<name>WP03-C</name>
        //</rtept>
        //<rtept lat="18.47579" lon="-69.91113">
        //<name>WP04-D</name>
        //</rtept>
        //<rtept lat="18.47627" lon="-69.91171">
        //<name>WP05-E</name>
        //</rtept>
        //<rtept lat="18.47638" lon="-69.91246">
        //<name>WP06-F</name>
        //</rtept>
        //<rtept lat="18.47623" lon="-69.91334">
        //<name>WP07-G</name>
        //</rtept>
        //<rtept lat="18.47623" lon="-69.91394">
        //<name>WP08-H</name>
        //</rtept>
        //<rtept lat="18.47587" lon="-69.9148">
        //<name>WP09-I</name>
        //</rtept>
        //<rtept lat="18.47562" lon="-69.91576">
        //<name>WP10-J</name>
        //</rtept>
        //<rtept lat="18.47503" lon="-69.91651">
        //<name>WP11-K</name>
        //</rtept>
        //<rtept lat="18.47471" lon="-69.91692">
        //<name>WP12-L</name>
        //</rtept>
        //<rtept lat="18.4743" lon="-69.91748">
        //<name>WP13-M</name>
        //</rtept>
        //<rtept lat="18.47375" lon="-69.91795">
        //<name>WP14-N</name>
        //</rtept>
        //<rtept lat="18.47328" lon="-69.91853">
        //<name>WP15-O</name>
        //</rtept>
        //<rtept lat="18.47281" lon="-69.91905">
        //<name>WP16-P</name>
        //</rtept>
        //<rtept lat="18.47261" lon="-69.91939">
        //<name>WP17-Q</name>
        //</rtept>
        //<rtept lat="18.47245" lon="-69.9198">
        //<name>WP18-R</name>
        //</rtept>
        //<rtept lat="18.47206" lon="-69.92014">
        //<name>WP19-S</name>
        //</rtept>
        //</rte>
        //</gpx>
        //""";
        //        private const string GpxData2 =
        //"""
        //<?xml version="1.0" encoding="UTF-8" standalone="no" ?>
        //<gpx version="1.1" creator="http://www.geoplaner.com" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.topografix.com/GPX/1/1" xsi:schemaLocation="http://www.topografix.com/GPX/1/1 http://www.topografix.com/GPX/1/1/gpx.xsd">
        //<rte>
        //<name>Route2a</name>
        //<rtept lat="18.46784" lon="-69.91132">
        //<name>WP01-A</name>
        //</rtept>
        //<rtept lat="18.46941" lon="-69.91166">
        //<name>WP02-B</name>
        //</rtept>
        //<rtept lat="18.47065" lon="-69.91199">
        //<name>WP03-C</name>
        //</rtept>
        //<rtept lat="18.47203" lon="-69.91239">
        //<name>WP04-D</name>
        //</rtept>
        //<rtept lat="18.47334" lon="-69.91267">
        //<name>WP05-E</name>
        //</rtept>
        //<rtept lat="18.47448" lon="-69.91297">
        //<name>WP06-F</name>
        //</rtept>
        //<rtept lat="18.47663" lon="-69.91347">
        //<name>WP07-G</name>
        //</rtept>
        //<rtept lat="18.4783" lon="-69.91385">
        //<name>WP08-H</name>
        //</rtept>
        //</rte>
        //</gpx>
        //""";
        //        private const string GpxData3 =
        //"""
        //<?xml version="1.0" encoding="UTF-8" standalone="no" ?>
        //<gpx version="1.1" creator="http://www.geoplaner.com" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.topografix.com/GPX/1/1" xsi:schemaLocation="http://www.topografix.com/GPX/1/1 http://www.topografix.com/GPX/1/1/gpx.xsd">
        //<rte>
        //<name>Route3</name>
        //<rtept lat="18.45926" lon="-69.90716">
        //<name>WP01-A</name>
        //</rtept>
        //<rtept lat="18.46081" lon="-69.90802">
        //<name>WP02-B</name>
        //</rtept>
        //<rtept lat="18.46235" lon="-69.90892">
        //<name>WP03-C</name>
        //</rtept>
        //<rtept lat="18.46327" lon="-69.90923">
        //<name>WP04-D</name>
        //</rtept>
        //<rtept lat="18.46368" lon="-69.90947">
        //<name>WP05-E</name>
        //</rtept>
        //<rtept lat="18.4642" lon="-69.90976">
        //<name>WP06-F</name>
        //</rtept>
        //<rtept lat="18.46475" lon="-69.9099">
        //<name>WP07-G</name>
        //</rtept>
        //<rtept lat="18.46523" lon="-69.91025">
        //<name>WP08-H</name>
        //</rtept>
        //<rtept lat="18.46578" lon="-69.9105">
        //<name>WP09-I</name>
        //</rtept>
        //<rtept lat="18.46613" lon="-69.91067">
        //<name>WP10-J</name>
        //</rtept>
        //<rtept lat="18.4667" lon="-69.91092">
        //<name>WP11-K</name>
        //</rtept>
        //<rtept lat="18.46726" lon="-69.91117">
        //<name>WP12-L</name>
        //</rtept>
        //<rtept lat="18.46782" lon="-69.91126">
        //<name>WP13-M</name>
        //</rtept>
        //<rtept lat="18.46834" lon="-69.91146">
        //<name>WP14-N</name>
        //</rtept>
        //<rtept lat="18.46889" lon="-69.91156">
        //<name>WP15-O</name>
        //</rtept>
        //<rtept lat="18.46941" lon="-69.91169">
        //<name>WP16-P</name>
        //</rtept>
        //<rtept lat="18.46993" lon="-69.91184">
        //<name>WP17-Q</name>
        //</rtept>
        //<rtept lat="18.47049" lon="-69.91199">
        //<name>WP18-R</name>
        //</rtept>
        //<rtept lat="18.4711" lon="-69.91215">
        //<name>WP19-S</name>
        //</rtept>
        //<rtept lat="18.47177" lon="-69.91237">
        //<name>WP20-T</name>
        //</rtept>
        //<rtept lat="18.47226" lon="-69.91248">
        //<name>WP21-U</name>
        //</rtept>
        //<rtept lat="18.47277" lon="-69.91261">
        //<name>WP22-V</name>
        //</rtept>
        //<rtept lat="18.47333" lon="-69.91277">
        //<name>WP23-W</name>
        //</rtept>
        //<rtept lat="18.47389" lon="-69.91289">
        //<name>WP24-X</name>
        //</rtept>
        //<rtept lat="18.47444" lon="-69.91301">
        //<name>WP25-Y</name>
        //</rtept>
        //<rtept lat="18.47517" lon="-69.91315">
        //<name>WP26-Z</name>
        //</rtept>
        //<rtept lat="18.47569" lon="-69.91328">
        //<name>WP27</name>
        //</rtept>
        //<rtept lat="18.47621" lon="-69.91346">
        //<name>WP28</name>
        //</rtept>
        //<rtept lat="18.47688" lon="-69.91357">
        //<name>WP29</name>
        //</rtept>
        //<rtept lat="18.47749" lon="-69.91376">
        //<name>WP30</name>
        //</rtept>
        //<rtept lat="18.47821" lon="-69.91388">
        //<name>WP31</name>
        //</rtept>
        //<rtept lat="18.47892" lon="-69.91401">
        //<name>WP32</name>
        //</rtept>
        //<rtept lat="18.47956" lon="-69.91402">
        //<name>WP33</name>
        //</rtept>
        //<rtept lat="18.48009" lon="-69.91409">
        //<name>WP34</name>
        //</rtept>
        //<rtept lat="18.4807" lon="-69.91418">
        //<name>WP35</name>
        //</rtept>
        //<rtept lat="18.48129" lon="-69.9142">
        //<name>WP36</name>
        //</rtept>
        //<rtept lat="18.48193" lon="-69.91425">
        //<name>WP37</name>
        //</rtept>
        //<rtept lat="18.48251" lon="-69.91434">
        //<name>WP38</name>
        //</rtept>
        //<rtept lat="18.48318" lon="-69.91431">
        //<name>WP39</name>
        //</rtept>
        //</rte>
        //</gpx>
        //""";

        private const string GpxData1 =
""""
<?xml version="1.0" encoding="UTF-8" standalone="no" ?>
<gpx version="1.1" creator="http://www.geoplaner.com" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.topografix.com/GPX/1/1" xsi:schemaLocation="http://www.topografix.com/GPX/1/1 http://www.topografix.com/GPX/1/1/gpx.xsd">
<rte>
<name>RouteA</name>
<rtept lat="18.46642" lon="-69.91068">
<name>WP01-A</name>
</rtept>
<rtept lat="18.46667" lon="-69.91084">
<name>WP02-B</name>
</rtept>
<rtept lat="18.46699" lon="-69.91102">
<name>WP03-C</name>
</rtept>
<rtept lat="18.4675" lon="-69.91119">
<name>WP04-D</name>
</rtept>
<rtept lat="18.46795" lon="-69.91131">
<name>WP05-E</name>
</rtept>
<rtept lat="18.46843" lon="-69.91141">
<name>WP06-F</name>
</rtept>
<rtept lat="18.46887" lon="-69.91155">
<name>WP07-G</name>
</rtept>
<rtept lat="18.46934" lon="-69.91165">
<name>WP08-H</name>
</rtept>
<rtept lat="18.46978" lon="-69.91176">
<name>WP09-I</name>
</rtept>
<rtept lat="18.47022" lon="-69.91187">
<name>WP10-J</name>
</rtept>
<rtept lat="18.4707" lon="-69.912">
<name>WP11-K</name>
</rtept>
<rtept lat="18.47115" lon="-69.91212">
<name>WP12-L</name>
</rtept>
<rtept lat="18.47138" lon="-69.91218">
<name>WP13-M</name>
</rtept>
<rtept lat="18.47165" lon="-69.91225">
<name>WP14-N</name>
</rtept>
<rtept lat="18.47191" lon="-69.91234">
<name>WP15-O</name>
</rtept>
<rtept lat="18.4722" lon="-69.91241">
<name>WP16-P</name>
</rtept>
<rtept lat="18.47245" lon="-69.91247">
<name>WP17-Q</name>
</rtept>
<rtept lat="18.47271" lon="-69.91255">
<name>WP18-R</name>
</rtept>
<rtept lat="18.47296" lon="-69.91262">
<name>WP19-S</name>
</rtept>
<rtept lat="18.47323" lon="-69.91267">
<name>WP20-T</name>
</rtept>
<rtept lat="18.47352" lon="-69.91274">
<name>WP21-U</name>
</rtept>
<rtept lat="18.47377" lon="-69.91281">
<name>WP22-V</name>
</rtept>
<rtept lat="18.47402" lon="-69.91287">
<name>WP23-W</name>
</rtept>
<rtept lat="18.47427" lon="-69.91293">
<name>WP24-X</name>
</rtept>
<rtept lat="18.47456" lon="-69.913">
<name>WP25-Y</name>
</rtept>
<rtept lat="18.47476" lon="-69.91307">
<name>WP26-Z</name>
</rtept>
<rtept lat="18.47493" lon="-69.91311">
<name>WP27</name>
</rtept>
<rtept lat="18.47511" lon="-69.91314">
<name>WP28</name>
</rtept>
<rtept lat="18.47535" lon="-69.91319">
<name>WP29</name>
</rtept>
<rtept lat="18.47561" lon="-69.91327">
<name>WP30</name>
</rtept>
<rtept lat="18.47587" lon="-69.91334">
<name>WP31</name>
</rtept>
<rtept lat="18.47612" lon="-69.91339">
<name>WP32</name>
</rtept>
<rtept lat="18.47638" lon="-69.91345">
<name>WP33</name>
</rtept>
<rtept lat="18.47663" lon="-69.91349">
<name>WP34</name>
</rtept>
<rtept lat="18.47688" lon="-69.91354">
<name>WP35</name>
</rtept>
<rtept lat="18.47714" lon="-69.9136">
<name>WP36</name>
</rtept>
<rtept lat="18.47739" lon="-69.91364">
<name>WP37</name>
</rtept>
<rtept lat="18.47763" lon="-69.91369">
<name>WP38</name>
</rtept>
<rtept lat="18.47789" lon="-69.91374">
<name>WP39</name>
</rtept>
<rtept lat="18.47813" lon="-69.91378">
<name>WP40</name>
</rtept>
<rtept lat="18.47838" lon="-69.91382">
<name>WP41</name>
</rtept>
<rtept lat="18.47861" lon="-69.91385">
<name>WP42</name>
</rtept>
<rtept lat="18.47887" lon="-69.91387">
<name>WP43</name>
</rtept>
<rtept lat="18.47912" lon="-69.91391">
<name>WP44</name>
</rtept>
<rtept lat="18.47936" lon="-69.91393">
<name>WP45</name>
</rtept>
<rtept lat="18.47962" lon="-69.91397">
<name>WP46</name>
</rtept>
<rtept lat="18.47989" lon="-69.91401">
<name>WP47</name>
</rtept>
<rtept lat="18.48014" lon="-69.91405">
<name>WP48</name>
</rtept>
<rtept lat="18.48041" lon="-69.91408">
<name>WP49</name>
</rtept>
<rtept lat="18.48062" lon="-69.9141">
<name>WP50</name>
</rtept>
<rtept lat="18.48088" lon="-69.91415">
<name>WP51</name>
</rtept>
<rtept lat="18.48113" lon="-69.91414">
<name>WP52</name>
</rtept>
<rtept lat="18.48138" lon="-69.91416">
<name>WP53</name>
</rtept>
<rtept lat="18.48162" lon="-69.91416">
<name>WP54</name>
</rtept>
<rtept lat="18.48185" lon="-69.91416">
<name>WP55</name>
</rtept>
</rte>
</gpx>

"""";
        private const string GpxData2 =
""""
<?xml version="1.0" encoding="UTF-8" standalone="no" ?>
<gpx version="1.1" creator="http://www.geoplaner.com" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.topografix.com/GPX/1/1" xsi:schemaLocation="http://www.topografix.com/GPX/1/1 http://www.topografix.com/GPX/1/1/gpx.xsd">
<rte>
<name>Route1</name>
<rtept lat="18.47598" lon="-69.90839">
<name>WP01-A</name>
</rtept>
<rtept lat="18.47601" lon="-69.90847">
<name>WP02-B</name>
</rtept>
<rtept lat="18.476" lon="-69.90855">
<name>WP03-C</name>
</rtept>
<rtept lat="18.47602" lon="-69.90863">
<name>WP04-D</name>
</rtept>
<rtept lat="18.47602" lon="-69.90869">
<name>WP05-E</name>
</rtept>
<rtept lat="18.47603" lon="-69.90879">
<name>WP06-F</name>
</rtept>
<rtept lat="18.47605" lon="-69.90886">
<name>WP07-G</name>
</rtept>
<rtept lat="18.47605" lon="-69.90894">
<name>WP08-H</name>
</rtept>
<rtept lat="18.47606" lon="-69.90905">
<name>WP09-I</name>
</rtept>
<rtept lat="18.47608" lon="-69.90915">
<name>WP10-J</name>
</rtept>
<rtept lat="18.47608" lon="-69.90925">
<name>WP11-K</name>
</rtept>
<rtept lat="18.47611" lon="-69.90935">
<name>WP12-L</name>
</rtept>
<rtept lat="18.47611" lon="-69.90942">
<name>WP13-M</name>
</rtept>
<rtept lat="18.47612" lon="-69.90952">
<name>WP14-N</name>
</rtept>
<rtept lat="18.47613" lon="-69.90963">
<name>WP15-O</name>
</rtept>
<rtept lat="18.47615" lon="-69.90973">
<name>WP16-P</name>
</rtept>
<rtept lat="18.47617" lon="-69.90985">
<name>WP17-Q</name>
</rtept>
<rtept lat="18.47619" lon="-69.90994">
<name>WP18-R</name>
</rtept>
<rtept lat="18.4762" lon="-69.91001">
<name>WP19-S</name>
</rtept>
<rtept lat="18.47621" lon="-69.9101">
<name>WP20-T</name>
</rtept>
<rtept lat="18.47622" lon="-69.91018">
<name>WP21-U</name>
</rtept>
<rtept lat="18.47623" lon="-69.91028">
<name>WP22-V</name>
</rtept>
<rtept lat="18.47624" lon="-69.91037">
<name>WP23-W</name>
</rtept>
<rtept lat="18.47626" lon="-69.91045">
<name>WP24-X</name>
</rtept>
<rtept lat="18.47626" lon="-69.91052">
<name>WP25-Y</name>
</rtept>
<rtept lat="18.47628" lon="-69.9106">
<name>WP26-Z</name>
</rtept>
<rtept lat="18.4763" lon="-69.91068">
<name>WP27</name>
</rtept>
<rtept lat="18.4763" lon="-69.91074">
<name>WP28</name>
</rtept>
<rtept lat="18.4763" lon="-69.91082">
<name>WP29</name>
</rtept>
<rtept lat="18.47632" lon="-69.9109">
<name>WP30</name>
</rtept>
<rtept lat="18.47632" lon="-69.91097">
<name>WP31</name>
</rtept>
<rtept lat="18.47633" lon="-69.91105">
<name>WP32</name>
</rtept>
<rtept lat="18.47634" lon="-69.91113">
<name>WP33</name>
</rtept>
<rtept lat="18.47634" lon="-69.91119">
<name>WP34</name>
</rtept>
<rtept lat="18.47636" lon="-69.91127">
<name>WP35</name>
</rtept>
<rtept lat="18.47638" lon="-69.91134">
<name>WP36</name>
</rtept>
<rtept lat="18.4764" lon="-69.91144">
<name>WP37</name>
</rtept>
<rtept lat="18.47641" lon="-69.91154">
<name>WP38</name>
</rtept>
<rtept lat="18.47642" lon="-69.91163">
<name>WP39</name>
</rtept>
<rtept lat="18.47642" lon="-69.9117">
<name>WP40</name>
</rtept>
<rtept lat="18.47642" lon="-69.91178">
<name>WP41</name>
</rtept>
<rtept lat="18.47643" lon="-69.91185">
<name>WP42</name>
</rtept>
<rtept lat="18.47643" lon="-69.91192">
<name>WP43</name>
</rtept>
<rtept lat="18.47644" lon="-69.91201">
<name>WP44</name>
</rtept>
<rtept lat="18.47644" lon="-69.91211">
<name>WP45</name>
</rtept>
<rtept lat="18.47645" lon="-69.91223">
<name>WP46</name>
</rtept>
<rtept lat="18.47644" lon="-69.91229">
<name>WP47</name>
</rtept>
<rtept lat="18.47645" lon="-69.91239">
<name>WP48</name>
</rtept>
<rtept lat="18.47646" lon="-69.91248">
<name>WP49</name>
</rtept>
<rtept lat="18.47646" lon="-69.91253">
<name>WP50</name>
</rtept>
<rtept lat="18.47647" lon="-69.91261">
<name>WP51</name>
</rtept>
<rtept lat="18.47647" lon="-69.91267">
<name>WP52</name>
</rtept>
<rtept lat="18.47646" lon="-69.91277">
<name>WP53</name>
</rtept>
<rtept lat="18.47646" lon="-69.91284">
<name>WP54</name>
</rtept>
<rtept lat="18.47644" lon="-69.9129">
<name>WP55</name>
</rtept>
<rtept lat="18.47644" lon="-69.91297">
<name>WP56</name>
</rtept>
<rtept lat="18.47644" lon="-69.91305">
<name>WP57</name>
</rtept>
<rtept lat="18.47642" lon="-69.91312">
<name>WP58</name>
</rtept>
<rtept lat="18.47641" lon="-69.91321">
<name>WP59</name>
</rtept>
<rtept lat="18.4764" lon="-69.91328">
<name>WP60</name>
</rtept>
<rtept lat="18.47638" lon="-69.91336">
<name>WP61</name>
</rtept>
<rtept lat="18.47639" lon="-69.91344">
<name>WP62</name>
</rtept>
<rtept lat="18.47638" lon="-69.91351">
<name>WP63</name>
</rtept>
<rtept lat="18.47637" lon="-69.91358">
<name>WP64</name>
</rtept>
<rtept lat="18.47637" lon="-69.91361">
<name>WP65</name>
</rtept>
<rtept lat="18.47636" lon="-69.91366">
<name>WP66</name>
</rtept>
<rtept lat="18.47633" lon="-69.91374">
<name>WP67</name>
</rtept>
<rtept lat="18.47633" lon="-69.91384">
<name>WP68</name>
</rtept>
<rtept lat="18.47631" lon="-69.91392">
<name>WP69</name>
</rtept>
<rtept lat="18.47629" lon="-69.91398">
<name>WP70</name>
</rtept>
<rtept lat="18.47628" lon="-69.91405">
<name>WP71</name>
</rtept>
<rtept lat="18.47625" lon="-69.9141">
<name>WP72</name>
</rtept>
<rtept lat="18.47624" lon="-69.91416">
<name>WP73</name>
</rtept>
<rtept lat="18.47622" lon="-69.91423">
<name>WP74</name>
</rtept>
<rtept lat="18.47617" lon="-69.91431">
<name>WP75</name>
</rtept>
<rtept lat="18.47617" lon="-69.91436">
<name>WP76</name>
</rtept>
<rtept lat="18.47615" lon="-69.91442">
<name>WP77</name>
</rtept>
<rtept lat="18.47611" lon="-69.9145">
<name>WP78</name>
</rtept>
<rtept lat="18.47608" lon="-69.91457">
<name>WP79</name>
</rtept>
<rtept lat="18.47607" lon="-69.91462">
<name>WP80</name>
</rtept>
<rtept lat="18.47604" lon="-69.9147">
<name>WP81</name>
</rtept>
<rtept lat="18.47602" lon="-69.91477">
<name>WP82</name>
</rtept>
<rtept lat="18.47601" lon="-69.91481">
<name>WP83</name>
</rtept>
<rtept lat="18.47598" lon="-69.91486">
<name>WP84</name>
</rtept>
<rtept lat="18.47594" lon="-69.91492">
<name>WP85</name>
</rtept>
<rtept lat="18.47594" lon="-69.91501">
<name>WP86</name>
</rtept>
<rtept lat="18.4759" lon="-69.91509">
<name>WP87</name>
</rtept>
<rtept lat="18.47586" lon="-69.91513">
<name>WP88</name>
</rtept>
<rtept lat="18.47585" lon="-69.9152">
<name>WP89</name>
</rtept>
<rtept lat="18.47582" lon="-69.91524">
<name>WP90</name>
</rtept>
<rtept lat="18.47581" lon="-69.91529">
<name>WP91</name>
</rtept>
<rtept lat="18.47578" lon="-69.91535">
<name>WP92</name>
</rtept>
<rtept lat="18.47577" lon="-69.9154">
<name>WP93</name>
</rtept>
<rtept lat="18.47576" lon="-69.91543">
<name>WP94</name>
</rtept>
<rtept lat="18.47574" lon="-69.91547">
<name>WP95</name>
</rtept>
<rtept lat="18.4757" lon="-69.91552">
<name>WP96</name>
</rtept>
<rtept lat="18.47567" lon="-69.91557">
<name>WP97</name>
</rtept>
<rtept lat="18.47563" lon="-69.91563">
<name>WP98</name>
</rtept>
<rtept lat="18.4756" lon="-69.91568">
<name>WP99</name>
</rtept>
<rtept lat="18.47556" lon="-69.91577">
<name>WP100</name>
</rtept>
<rtept lat="18.47552" lon="-69.91583">
<name>WP101</name>
</rtept>
<rtept lat="18.47547" lon="-69.9159">
<name>WP102</name>
</rtept>
<rtept lat="18.47547" lon="-69.91597">
<name>WP103</name>
</rtept>
<rtept lat="18.47543" lon="-69.91601">
<name>WP104</name>
</rtept>
<rtept lat="18.47537" lon="-69.91609">
<name>WP105</name>
</rtept>
<rtept lat="18.47531" lon="-69.91616">
<name>WP106</name>
</rtept>
<rtept lat="18.47529" lon="-69.91622">
<name>WP107</name>
</rtept>
<rtept lat="18.47524" lon="-69.91626">
<name>WP108</name>
</rtept>
<rtept lat="18.47521" lon="-69.91632">
<name>WP109</name>
</rtept>
<rtept lat="18.47518" lon="-69.91636">
<name>WP110</name>
</rtept>
<rtept lat="18.47513" lon="-69.9164">
<name>WP111</name>
</rtept>
<rtept lat="18.47511" lon="-69.91645">
<name>WP112</name>
</rtept>
<rtept lat="18.47506" lon="-69.91649">
<name>WP113</name>
</rtept>
<rtept lat="18.47503" lon="-69.91655">
<name>WP114</name>
</rtept>
<rtept lat="18.47498" lon="-69.9166">
<name>WP115</name>
</rtept>
<rtept lat="18.47495" lon="-69.91667">
<name>WP116</name>
</rtept>
<rtept lat="18.4749" lon="-69.91669">
<name>WP117</name>
</rtept>
<rtept lat="18.4749" lon="-69.91674">
<name>WP118</name>
</rtept>
<rtept lat="18.47485" lon="-69.91676">
<name>WP119</name>
</rtept>
<rtept lat="18.4748" lon="-69.91684">
<name>WP120</name>
</rtept>
<rtept lat="18.47475" lon="-69.91689">
<name>WP121</name>
</rtept>
<rtept lat="18.47473" lon="-69.91696">
<name>WP122</name>
</rtept>
<rtept lat="18.47467" lon="-69.91698">
<name>WP123</name>
</rtept>
<rtept lat="18.47462" lon="-69.91704">
<name>WP124</name>
</rtept>
<rtept lat="18.47458" lon="-69.91709">
<name>WP125</name>
</rtept>
<rtept lat="18.47455" lon="-69.91713">
<name>WP126</name>
</rtept>
<rtept lat="18.4745" lon="-69.91721">
<name>WP127</name>
</rtept>
<rtept lat="18.47445" lon="-69.91725">
<name>WP128</name>
</rtept>
<rtept lat="18.47442" lon="-69.91731">
<name>WP129</name>
</rtept>
<rtept lat="18.47437" lon="-69.91734">
<name>WP130</name>
</rtept>
<rtept lat="18.47433" lon="-69.9174">
<name>WP131</name>
</rtept>
<rtept lat="18.4743" lon="-69.91742">
<name>WP132</name>
</rtept>
<rtept lat="18.47425" lon="-69.91748">
<name>WP133</name>
</rtept>
<rtept lat="18.47419" lon="-69.91754">
<name>WP134</name>
</rtept>
<rtept lat="18.47415" lon="-69.9176">
<name>WP135</name>
</rtept>
<rtept lat="18.47411" lon="-69.91765">
<name>WP136</name>
</rtept>
<rtept lat="18.47407" lon="-69.91771">
<name>WP137</name>
</rtept>
<rtept lat="18.47405" lon="-69.91774">
<name>WP138</name>
</rtept>
<rtept lat="18.474" lon="-69.91781">
<name>WP139</name>
</rtept>
<rtept lat="18.47396" lon="-69.91786">
<name>WP140</name>
</rtept>
<rtept lat="18.47393" lon="-69.91792">
<name>WP141</name>
</rtept>
<rtept lat="18.47389" lon="-69.91797">
<name>WP142</name>
</rtept>
<rtept lat="18.47384" lon="-69.91801">
<name>WP143</name>
</rtept>
<rtept lat="18.4738" lon="-69.91807">
<name>WP144</name>
</rtept>
<rtept lat="18.47375" lon="-69.91811">
<name>WP145</name>
</rtept>
</rte>
</gpx>
"""";
        private const string GpxData3 =
""""
<?xml version="1.0" encoding="UTF-8" standalone="no" ?>
<gpx version="1.1" creator="http://www.geoplaner.com" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.topografix.com/GPX/1/1" xsi:schemaLocation="http://www.topografix.com/GPX/1/1 http://www.topografix.com/GPX/1/1/gpx.xsd">
<rte>
<name>Route1</name>
<rtept lat="18.47623" lon="-69.91048">
<name>WP01-A</name>
</rtept>
<rtept lat="18.47628" lon="-69.91063">
<name>WP02-B</name>
</rtept>
<rtept lat="18.47628" lon="-69.91074">
<name>WP03-C</name>
</rtept>
<rtept lat="18.47629" lon="-69.91083">
<name>WP04-D</name>
</rtept>
<rtept lat="18.47632" lon="-69.91095">
<name>WP05-E</name>
</rtept>
<rtept lat="18.47633" lon="-69.91105">
<name>WP06-F</name>
</rtept>
<rtept lat="18.47634" lon="-69.91114">
<name>WP07-G</name>
</rtept>
<rtept lat="18.47635" lon="-69.91124">
<name>WP08-H</name>
</rtept>
<rtept lat="18.47636" lon="-69.91133">
<name>WP09-I</name>
</rtept>
<rtept lat="18.47638" lon="-69.91143">
<name>WP10-J</name>
</rtept>
<rtept lat="18.4764" lon="-69.91151">
<name>WP11-K</name>
</rtept>
<rtept lat="18.4764" lon="-69.91159">
<name>WP12-L</name>
</rtept>
<rtept lat="18.47639" lon="-69.91171">
<name>WP13-M</name>
</rtept>
<rtept lat="18.47642" lon="-69.9118">
<name>WP14-N</name>
</rtept>
<rtept lat="18.47642" lon="-69.9119">
<name>WP15-O</name>
</rtept>
<rtept lat="18.47643" lon="-69.91199">
<name>WP16-P</name>
</rtept>
<rtept lat="18.47643" lon="-69.91209">
<name>WP17-Q</name>
</rtept>
<rtept lat="18.47644" lon="-69.91218">
<name>WP18-R</name>
</rtept>
<rtept lat="18.47645" lon="-69.91227">
<name>WP19-S</name>
</rtept>
<rtept lat="18.47644" lon="-69.91237">
<name>WP20-T</name>
</rtept>
<rtept lat="18.47646" lon="-69.91244">
<name>WP21-U</name>
</rtept>
<rtept lat="18.47644" lon="-69.91252">
<name>WP22-V</name>
</rtept>
<rtept lat="18.47646" lon="-69.91262">
<name>WP23-W</name>
</rtept>
<rtept lat="18.47647" lon="-69.91271">
<name>WP24-X</name>
</rtept>
<rtept lat="18.47644" lon="-69.91279">
<name>WP25-Y</name>
</rtept>
<rtept lat="18.47644" lon="-69.91289">
<name>WP26-Z</name>
</rtept>
<rtept lat="18.47641" lon="-69.91297">
<name>WP27</name>
</rtept>
<rtept lat="18.47642" lon="-69.91309">
<name>WP28</name>
</rtept>
<rtept lat="18.47642" lon="-69.9132">
<name>WP29</name>
</rtept>
<rtept lat="18.47639" lon="-69.91329">
<name>WP30</name>
</rtept>
<rtept lat="18.47636" lon="-69.91338">
<name>WP31</name>
</rtept>
<rtept lat="18.47635" lon="-69.91345">
<name>WP32</name>
</rtept>
<rtept lat="18.47633" lon="-69.91356">
<name>WP33</name>
</rtept>
<rtept lat="18.47632" lon="-69.91363">
<name>WP34</name>
</rtept>
<rtept lat="18.47632" lon="-69.91368">
<name>WP35</name>
</rtept>
<rtept lat="18.47632" lon="-69.91378">
<name>WP36</name>
</rtept>
<rtept lat="18.47631" lon="-69.91388">
<name>WP37</name>
</rtept>
<rtept lat="18.47628" lon="-69.91395">
<name>WP38</name>
</rtept>
<rtept lat="18.47627" lon="-69.91405">
<name>WP39</name>
</rtept>
<rtept lat="18.47623" lon="-69.91414">
<name>WP40</name>
</rtept>
<rtept lat="18.47619" lon="-69.91424">
<name>WP41</name>
</rtept>
<rtept lat="18.47617" lon="-69.91438">
<name>WP42</name>
</rtept>
<rtept lat="18.47613" lon="-69.91449">
<name>WP43</name>
</rtept>
<rtept lat="18.47609" lon="-69.91461">
<name>WP44</name>
</rtept>
<rtept lat="18.47604" lon="-69.91473">
<name>WP45</name>
</rtept>
<rtept lat="18.47602" lon="-69.91485">
<name>WP46</name>
</rtept>
<rtept lat="18.47596" lon="-69.91497">
<name>WP47</name>
</rtept>
<rtept lat="18.47591" lon="-69.91509">
<name>WP48</name>
</rtept>
<rtept lat="18.47589" lon="-69.91517">
<name>WP49</name>
</rtept>
<rtept lat="18.47587" lon="-69.91523">
<name>WP50</name>
</rtept>
<rtept lat="18.47583" lon="-69.9153">
<name>WP51</name>
</rtept>
<rtept lat="18.47581" lon="-69.91536">
<name>WP52</name>
</rtept>
<rtept lat="18.47577" lon="-69.91542">
<name>WP53</name>
</rtept>
<rtept lat="18.47573" lon="-69.9155">
<name>WP54</name>
</rtept>
<rtept lat="18.4757" lon="-69.91558">
<name>WP55</name>
</rtept>
<rtept lat="18.47563" lon="-69.91566">
<name>WP56</name>
</rtept>
<rtept lat="18.47558" lon="-69.91579">
<name>WP57</name>
</rtept>
<rtept lat="18.4755" lon="-69.91589">
<name>WP58</name>
</rtept>
<rtept lat="18.47547" lon="-69.91597">
<name>WP59</name>
</rtept>
<rtept lat="18.47543" lon="-69.91606">
<name>WP60</name>
</rtept>
<rtept lat="18.47537" lon="-69.91614">
<name>WP61</name>
</rtept>
<rtept lat="18.4753" lon="-69.9162">
<name>WP62</name>
</rtept>
<rtept lat="18.47525" lon="-69.9163">
<name>WP63</name>
</rtept>
<rtept lat="18.4752" lon="-69.91637">
<name>WP64</name>
</rtept>
<rtept lat="18.47515" lon="-69.91645">
<name>WP65</name>
</rtept>
<rtept lat="18.47507" lon="-69.91653">
<name>WP66</name>
</rtept>
<rtept lat="18.475" lon="-69.91662">
<name>WP67</name>
</rtept>
<rtept lat="18.47493" lon="-69.91667">
<name>WP68</name>
</rtept>
<rtept lat="18.4749" lon="-69.91674">
<name>WP69</name>
</rtept>
<rtept lat="18.47484" lon="-69.9168">
<name>WP70</name>
</rtept>
<rtept lat="18.47478" lon="-69.91689">
<name>WP71</name>
</rtept>
<rtept lat="18.47471" lon="-69.91697">
<name>WP72</name>
</rtept>
<rtept lat="18.47461" lon="-69.91707">
<name>WP73</name>
</rtept>
<rtept lat="18.47458" lon="-69.91712">
<name>WP74</name>
</rtept>
<rtept lat="18.47452" lon="-69.91717">
<name>WP75</name>
</rtept>
<rtept lat="18.47448" lon="-69.91725">
<name>WP76</name>
</rtept>
<rtept lat="18.47437" lon="-69.91734">
<name>WP77</name>
</rtept>
<rtept lat="18.47433" lon="-69.91741">
<name>WP78</name>
</rtept>
<rtept lat="18.47428" lon="-69.9175">
<name>WP79</name>
</rtept>
<rtept lat="18.47422" lon="-69.91758">
<name>WP80</name>
</rtept>
<rtept lat="18.47415" lon="-69.91767">
<name>WP81</name>
</rtept>
<rtept lat="18.47407" lon="-69.91775">
<name>WP82</name>
</rtept>
<rtept lat="18.47399" lon="-69.91786">
<name>WP83</name>
</rtept>
<rtept lat="18.47391" lon="-69.91793">
<name>WP84</name>
</rtept>
<rtept lat="18.47385" lon="-69.91802">
<name>WP85</name>
</rtept>
</rte>
</gpx>
"""";
        public BusTrackerService(IEnumerable<(string BusId, string GpxData)> busRoutes)
        {
            busRoutes = new List<(string, string)> 
            { 
                ("123", GpxData1), 
                ("254", GpxData2), 
                ("777", GpxData3) 
            };

            Buses = new List<Bus>();

            foreach (var busRoute in busRoutes)
            {
                var route = GpxParser.ParseRoute(busRoute.GpxData);
                Buses.Add(new Bus
                {
                    BusId = busRoute.BusId,
                    Route = route,
                    Capacity = 50, // Assume fixed capacity for simplicity
                    CurrentPassengers = random.Next(50), // Initialize with a random number of passengers
                    TimeToArrival = TimeSpan.FromMinutes(route.Count) // Assume one minute per route point
                });
            }
        }

        public List<Bus> GetUpdatedBusStatus()
        {
            foreach (var bus in Buses)
            {
                bus.CurrentPassengers = random.Next(bus.Capacity);
                if (bus.CurrentRouteIndex < bus.Route.Count - 1)
                {
                    bus.CurrentRouteIndex++;
                }
                bus.TimeToArrival -= TimeSpan.FromMinutes(1);
            }

            return Buses;
        }
    }
}

<!-- Do not edit this file. It was translated by Google. -->
<style>
  img {
  max-width: 100%;
  height: auto;
}
</style><mat-card><mat-card-title class="cardtitle"> Hönnun </mat-card-title>
<markdown ngPreserveWhitespaces>

<p> Skýringarmyndirnar hér að neðan sýna samspil hugbúnaðaríhluta. </p>

<ul>
<li>
<p> ClientApp er Angular Typescript forrit á einni síðu sem keyrir í vafranum. Það veitir notendaviðmótinu. </p>
</li>
<li>
<p> WebApp er <a href="https://github.com/aspnet/home">Asp.Net Core</a> C# forrit sem keyrir á netþjóninum. Það svarar WebApi símtölum. </p>
</li>
<li>
<p> WorkflowApp er <a href="https://github.com/dotnet/core">DotNet Core</a> C# forrit sem keyrir á netþjóninum. Það gerir hópvinnslu á upptökum og afritum. Einnig væri hægt að breyta því í bókasafn sem keyrir sem hluti af WebApp ferlinu. </p>
</li>
<li>
<p> Aðrir netþáttar eru DotNet Core C# bókasöfn. Þau eru notuð af bæði WebApp og WorkflowApp. </p>
</li>
</ul><hr /><h2> Kerfishönnun </h2>
</markdown>
<img src="assets/images/FlowchartSystem.png">
<markdown ngPreserveWhitespaces>

<p> Íhlutirnir í ofangreindu skýringarmyndinni eru: </p>

<table style="width:100%">
<tr><th colspan="2"> Forrit </th></tr>
<tr><td> Viðskiptavinur </td><td> Hyrndur SPA </td></tr>
<tr><td> WebApp </td><td> Asp.Net ferli vefþjónsins </td></tr>
<tr><td> VinnuflæðiApp </td><td> Verkferilsstjórnunarferli </td></tr>
<tr><th colspan="2"> Bókasöfn </th></tr>
<tr><td> GetOnlineFiles </td><td> Sæktu afrit og upptökur á netinu </td></tr>
<tr><td> ProcessRecording </td><td> Útdráttur og umritun hljóðs. Búðu til vinnuhluti. </td></tr>
<tr><td> ProcessTranscript </td><td> Umbreyta hráum afritum </td></tr>
<tr><td> LoadDatabase </td><td> Safnaðu gagnagrunni með gögnum frá lokið afriti </td></tr>
<tr><td> Netaðgang </td><td> Venja til að sækja skrá frá fjarlægum vefsvæðum </td></tr>
<tr><td> GoogleCloudAccess </td><td> Venjur til að fá aðgang að Google Cloud þjónustu </td></tr>
<tr><td> FileDataRepositories </td><td> Vistaðu og fáðu gögn um JSON vinnuskrá </td></tr>
<tr><td> Gagnasafn geymsla </td><td> Geymdu og fáðu gögn úr gagnagrunni úr gagnagrunni </td></tr>
<tr><td> Gagnasafnaðgangur </td><td> Fáðu aðgang að gagnagrunni með Entity Framework </td></tr>
</table>
<hr /><h2> ViðskiptavinurHönnun </h2>
</markdown>
<img src="assets/images/FlowchartClientApp.png">
<markdown ngPreserveWhitespaces>

<p> Uppbygging ClientApp er best sýnd með uppbyggingu hyrndra íhluta </p>

<table style="width:100%">
<tr><th colspan="2"> Íhlutir forrita </th></tr>
<tr><td> Haus </td><td> Haus </td></tr>
<tr><td> Sidenav </td><td> Siglingar á hliðarstiku </td></tr>
<tr><td> Mælaborð </td><td> Gámur fyrir íhluta mælaborðsins </td></tr>
<tr><td> Skjöl </td><td> Ílát fyrir skjalasíður </td></tr>
<tr><th colspan="2"> Íhlutir mælaborðsins </th></tr>
<tr><td> Fixasr </td><td> Lagaðu texta fyrir sjálfvirka talgreiningu </td></tr>
<tr><td> Addtags </td><td> Bættu merkjum við afrit </td></tr>
<tr><td> ViewTranscript </td><td> Skoða lokið afrit </td></tr>
<tr><td> Vandamál </td><td> Skoða upplýsingar um mál </td></tr>
<tr><td> Viðvaranir </td><td> Skoða og stilla upplýsingar um viðvaranir </td></tr>
<tr><td> Embættismenn </td><td> Skoða upplýsingar um embættismenn </td></tr>
<tr><td> (Aðrir) </td><td> Aðrir þættir sem koma til framkvæmda </td></tr>
<tr><th colspan="2"> Þjónusta </th></tr>
<tr><td> VirtualMeeting </td><td> Keyra sýndarfund </td></tr>
<tr><td> Spjallaðu </td><td> Spjallþáttur notanda </td></tr>
</table>
<hr /><h2> WebApp hönnun </h2>
</markdown>
<img src="assets/images/FlowchartWebApp.png">
<markdown ngPreserveWhitespaces>

<p> Hver af API API er lítil og kallar á geymslurnar til að setja eða fá gögn úr gagnagrunninum eða skráakerfinu. </p>

<table style="width:100%">
<tr><th colspan="2"> Stjórnendur </th></tr>
<tr><td> Fixasr </td><td> Vistaðu og fáðu nýjustu útgáfu afritsins sem verið er að lesa. </td></tr>
<tr><td> Addtags </td><td> Vistaðu og fáðu nýjustu útgáfuna af afritinu sem er merkt. </td></tr>
<tr><td> Útsýni </td><td> Fáðu nýjasta lokið skjalið. </td></tr>
<tr><td> Govbodies </td><td> Vistaðu og fáðu skráð gögn frá stjórnvöldum. </td></tr>
<tr><td> Fundir </td><td> Vistaðu og fáðu upplýsingar um fundinn. </td></tr>
<tr><td> Myndband </td><td> Fáðu myndband af fundinum. </td></tr>
<tr><td> Reikningur </td><td> Vinnið notendaskráningu og innskráningu. </td></tr>
<tr><td> Stjórna </td><td> Notendur geta stjórnað sniðunum sínum. </td></tr>
<tr><td> Stjórnandi </td><td> Stjórnandi getur stjórnað notendum, stefnum og kröfum </td></tr>
<tr><th colspan="2"> Þjónusta </th></tr>
<tr><td> Netfang </td><td> Meðhöndla staðfestingu tölvupósts á skráningu. </td></tr>
<tr><td> Skilaboð </td><td> Meðhöndla staðfestingu skráningar í sms. </td></tr>
</table>
<hr /><h2> VinnuflæðiApp Hönnun </h2>
</markdown>
<img src="assets/images/FlowchartWorkflowApp.png">
<markdown ngPreserveWhitespaces>

<p> Staða verkflæðis fyrir tiltekinn fund er geymd í fundarskránni í gagnagrunninum. Hver og einn af verkflæðisíhlutunum starfar sjálfstætt. Þeir eru hvor um sig kallaðir til að athuga hvort fyrirliggjandi vinna sé til staðar. Hver hluti mun spyrjast fyrir um gagnagrunninn fyrir fundi sem samsvara forsendum þeirra fyrir fyrirliggjandi vinnu. Ef vinna finnast munu þau framkvæma það og uppfæra stöðu fundarins í gagnagrunninum. </p>

<p> Til þess að byggja upp öflugt kerfi, sem getur náð sér eftir bilun, verðum við að meðhöndla skref í verkflæðinu sem „viðskipti“. Viðskiptum lýkur annað hvort að fullu eða alls ekki. Ef um órjúfanleg bilun er að ræða meðan á vinnsluferli stendur, rennur ríkið fyrir þann fund aftur í síðasta gildi. Kóðinn útfærir ekki viðskipti nú sem stendur. (Gitub mál að fylgja) </p>

<p> Gervi kóði er gefinn hér að neðan fyrir íhlutina </p>

<ul>
<li> RetreiveOnlineFiles </li>
<ul>
<li> Fyrir alla aðila ríkisins í kerfinu </li>
<ul>
<li> Athugaðu tímaáætlun fyrir fundi til að sækja </li>
<li> Sæktu annað hvort upptöku- eða afritaskrá </li>
<li> Settu skrána í DATAFILES \ Móttekin möppu </li>
</ul>
<li> Einnig er hægt að setja skrár í möppuna Móttekin með því að hlaða inn af notanda. </li>
</ul>
<li> ProcessReceivedFiles </li>
<ul>
<li> Fyrir skrár í DATAFILES \ Mótteknar og gagnagrunnsuppfærsla er ekki til: </li>
<ul>
<li> Ákvarðu skráargerð </li>
<li> Búa til gagnagrunn </li>
<li> setja stöðu = móttekin, samþykkt = ósönn </li>
<li> Senda stjórnanda (s) skilaboð: "Móttekið" </li>
</ul>
</ul>
<li> Transcribe Recording </li>
<ul>
<li> Fyrir upptökur með sourcetype = upptöku, staða = móttekin, samþykkt = satt </li>
<ul>
<li> Búðu til vinnumöppu </li>
<li> setja stöðu = afrita, samþykkt = ósatt </li>
<li> Transcribe upptöku </li>
<li> setja stöðu = umritað, samþykkt = ósatt </li>
<li> Senda stjórnanda (s) skilaboð: "Transcribed" </li>
</ul>
</ul>
<li> Aðferðafrit </li>
<ul>
<li> Fyrir afrit með sourcetype = afrit, staða = móttekin, samþykkt = satt </li>
<ul>
<li> Búðu til vinnumöppu </li>
<li> setja stöðu = vinnslu, samþykkt = ósatt </li>
<li> Að vinna úrrit </li>
<li> setja stöðu = afgreidd, samþykkt = ósönn </li>
<li> Senda stjórnanda (s) skilaboð: "Afgreitt" </li>
</ul>
</ul>
<li> Proofread Upptaka </li>
<ul>
<li> Fyrir upptökur með stöðu = umritaðar / samþykktar = satt </li>
<ul>
<li> Búðu til vinnumöppu </li>
<li> setja stöðu = prófarkalestur, samþykkt = ósatt </li>
<li> Handvirk prófarkalestur mun nú fara fram </li>
</ul>
<li> Fyrir upptökur með stöðu = prófarkalestur </li>
<ul>
<li> Athugaðu hvort prófarkalestur virðist lokið. Ef svo: </li>
<li> setja stöðu = prófarkalestur, samþykkt = ósatt </li>
<li> senda stjórnanda (s) skilaboð: "Proofread" </li>
</ul>
</ul>
<li> AddTagsToTranscript </li>
<ul>
<li> Fyrir upptökur með stöðu = prófarkalestur, samþykkt = satt EÐA fyrir afrit með stöðu = afgreitt, samþykkt = satt </li>
<ul>
<li> Búðu til vinnumöppu </li>
<li> stilla stöðu = merking, samþykkt = ósatt </li>
<li> Handvirk merking mun nú fara fram </li>
</ul>
</ul>
<ul>
<li> Fyrir afrit með stöðu = merkingu </li>
<ul>
<li> Athugaðu hvort merking virðist vera lokið. Ef svo: </li>
<li> setja stöðu = merkt, samþykkt = ósatt </li>
<li> senda stjórnanda (s) skilaboð: „merkt“ </li>
</ul>
</ul>
<li> LoadTranscript </li>
<ul>
<li> Fyrir fundi með stöðu = merkt, samþykkt = satt 
<ul>
<li> stilla stöðu = hleðsla, samþykkt = ósatt </li>
<li> hlaðið innihaldi fundarins í gagnagrunninn </li>
<li> setja stöðu = hlaðinn, samþykkt = ósatt </li>
<li> Senda stjórnanda (s) skilaboð: "Hlaðinn" </li>
</ul>
</ul>
</ul><hr /><h2> Leyndarmál notenda </h2>
<p> Leyndarmál notenda sem ættu ekki að vera í kóða geymslunni eru geymd í möppunni „SECRETS“. Það inniheldur eftirfarandi upplýsingar: </p>

<ul>
<li> ClientId og ClientSecret fyrir utanaðkomandi heimildarþjónustu Google. </li>
<li> SiteKey og Secret fyrir Google ReCaptcha þjónustuna. </li>
<li> Persónuskilríki fyrir Google Cloud Platform. </li>
<li> Strengur gagnatengingar. </li>
<li> Notandanafn og lykilorð stjórnanda. </li>
</ul>
<p> SECRETS möppan getur innihaldið fjórar skrár. </p>

<ul>
<li> appsettings.Development.json </li>
<li> appsettings.Production.json </li>
<li> stillingar.Staging.json </li>
<li> TranscribeAudio.json </li>
</ul>
<p> TranscribeAudio.json inniheldur Google Cloud Platform skilríki. Hver af öðrum þremur skrám getur innihaldið stillingar fyrir hvert annað leyndarmál. appsettings.Production.json ætti að innihalda allar stillingar fyrir framleiðslu. Hvaða stillingar sem eru í þessari skrá mun yfir þær sem eru í Server / WebApp / app.settings.json. Þessi skrá er innifalin í geymslunni. </p>

<p> Ef þú vilt að staðbundna vélin þín hafi aðgang að þjónustu Google þarftu að búa til staðbundna möppu "../SECRETS í tengslum við hvar geymslan er staðsett. Þá geturðu til dæmis bætt við skjalinu" appsettings.Development. json "við það, sem inniheldur lykla sem þú færð frá Google. Sjá: <a href="home#google-api-keys">Google API lyklar</a> </p>
<hr /><h1> Skjöl </h1>
<p> Upphaflega voru þessi skjöl geymd á Github Wiki síðunum. En það var ákveðið að færa síðurnar inn í aðalverkefnið af tveimur ástæðum: </p>

<ul>
<li> Þú getur ekki beðið Pull Beiðni um breytingar á Github Wiki síðum. Þetta gerir það erfitt fyrir meðlimi samfélagsins að breyta gögnum. </li>
<li> Gögnin munu líklegast vera í samstillingu við kóðann ef það er ásamt kóðanum í sömu geymslu. Ein PR fyrir kóðabreytingar getur innihaldið skjalabreytingarnar sem henni fylgja. </li>
</ul>
<p> Skjölin eru skrifuð í Markdown og eru í Frontend / ClientApp / src / app / eignum / skjölum. </p>

</markdown>

<p> &lt;/mat-card&gt; </p>
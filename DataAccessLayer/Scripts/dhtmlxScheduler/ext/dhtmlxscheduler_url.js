/*

@license
dhtmlxScheduler.Net v.4.0.2 Professional Evaluation

This software is covered by DHTMLX Evaluation License. Contact sales@dhtmlx.com to get Commercial or Enterprise license. Usage without proper license is prohibited.

(c) XB Software Ltd.

*/
Scheduler.plugin(function(e){e._get_url_nav=function(){for(var e={},t=(document.location.hash||"").replace("#","").split(","),a=0;a<t.length;a++){var n=t[a].split("=");2==n.length&&(e[n[0]]=n[1])}return e},e.attachEvent("onTemplatesReady",function(){function t(t){r=t,e.getEvent(t)&&e.showEvent(t)}var a=!0,n=e.date.str_to_date("%Y-%m-%d"),i=e.date.date_to_str("%Y-%m-%d"),r=e._get_url_nav().event||null;e.attachEvent("onAfterEventDisplay",function(e){return r=null,!0}),
e.attachEvent("onBeforeViewChange",function(o,d,l,_){if(a){a=!1;var s=e._get_url_nav();if(s.event)try{if(e.getEvent(s.event))return t(s.event),!1;var c=e.attachEvent("onXLE",function(){t(s.event),e.detachEvent(c)})}catch(e){}if(s.date||s.mode){try{this.setCurrentView(s.date?n(s.date):null,s.mode||null)}catch(e){this.setCurrentView(s.date?n(s.date):null,l)}return!1}}var u=["date="+i(_||d),"mode="+(l||o)];r&&u.push("event="+r);var h="#"+u.join(",");return document.location.hash=h,!0})})});
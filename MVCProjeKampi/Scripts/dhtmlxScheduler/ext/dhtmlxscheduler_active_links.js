/*

@license
dhtmlxScheduler.Net v.4.0.2 Professional Evaluation

This software is covered by DHTMLX Evaluation License. Contact sales@dhtmlx.com to get Commercial or Enterprise license. Usage without proper license is prohibited.

(c) XB Software Ltd.

*/
Scheduler.plugin(function(t){t.config.active_link_view="day",t._active_link_click=function(e){var i=e.target||event.srcElement,n=i.getAttribute("jump_to"),a=t.date.str_to_date(t.config.api_date);if(n)return t.setCurrentView(a(n),t.config.active_link_view),e&&e.preventDefault&&e.preventDefault(),!1},t.attachEvent("onTemplatesReady",function(){var e=function(e,i){i=i||e+"_scale_date",t.templates["_active_links_old_"+i]||(t.templates["_active_links_old_"+i]=t.templates[i])
;var n=t.templates["_active_links_old_"+i],a=t.date.date_to_str(t.config.api_date);t.templates[i]=function(t){return"<a jump_to='"+a(t)+"' href='#'>"+n(t)+"</a>"}};if(e("week"),e("","month_day"),this.matrix)for(var i in this.matrix)e(i);this._detachDomEvent(this._obj,"click",t._active_link_click),t.event(this._obj,"click",t._active_link_click)})});
﻿define(["base/base-grid-view"],function(e){"use strict";var t=e.extend({collectionType:null,tableName:null,showAddButton:!0,showEditButton:!0,showDeleteButton:!0,initialize:function(){t.__super__.initialize.apply(this,arguments),this.collection=new this.collectionType},render:function(){var e=this;return e.showAddButton&&(e.showAddButton=Application.canTableItemBeCreated(e.tableName)),e.showDeleteButton&&(e.showDeleteButton=Application.canTableItemBeDeleted(e.tableName)),e.showEditButton&&(e.showEditButton=Application.canTableItemBeEdit(e.tableName)),t.__super__.render.apply(e,arguments),e}});return t});
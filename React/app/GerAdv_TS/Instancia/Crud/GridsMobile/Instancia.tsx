// GridsMobile.tsx.txt
'use client';
import React from 'react';
import { Grid, GridColumn, GridFilterChangeEvent, GridPageChangeEvent, GridSortChangeEvent } from '@progress/kendo-react-grid';
import { IInstancia } from '../../Interfaces/interface.Instancia';
import { useRouter } from 'next/navigation';
import { useEffect, useState, useMemo } from 'react';
import { applyFilter, applyFilterToColumn, CRUD_CONSTANTS, sortData } from '@/app/tools/crud';
import { SvgIcon } from '@progress/kendo-react-common';
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';
interface InstanciaGridProps {
  data: IInstancia[];
  onRowClick: (instancia: IInstancia) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const InstanciaGridMobileComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: InstanciaGridProps) => {
const router = useRouter();
const [initialized, setInitialized] = useState(false);
const RowNumberCell = (props: any) => <td>{props.dataIndex + 1}</td>;
const [page, setPage] = useState({
  skip: 0, 
  take: 10, 
});
const [sort, setSort] = useState<any[]>([]);
const [columnFilters, setColumnFilters] = useState({
  nroprocesso: ''
});
const handleSortChange = (e: GridSortChangeEvent) => {
  setSort(e.sort);
};
const filteredData = useMemo(() => { return data.filter((data: any) => {
  const nroprocessoMatches = applyFilter(data, 'nroprocesso', columnFilters.nroprocesso);
  return nroprocessoMatches;
});
}, [data, columnFilters]);
const handleFilterChange = (event: GridFilterChangeEvent) => {
  const filters = event.filter?.filters || [];
  const newColumnFilters = { nroprocesso: '' };
  filters.forEach((filter) => applyFilterToColumn(filter, newColumnFilters));
  setColumnFilters(newColumnFilters);
};
const sortedFilteredData = sortData(filteredData, sort);
const handlePageChange = (event: GridPageChangeEvent) => {
  setPage({
    skip: event.page.skip, 
    take: event.page.take, 
  });
};
const handleRowClick = (e: any) => {
  onRowClick(e.dataItem);
};

const openConsultaNENotas = (id: number) => {
  router.push(`/pages/nenotas/?instancia=${id}`);
};
const EditarCellNENotas = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaNENotas(props.dataItem.id)}><span title='Editar N E Notas'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaProSucumbencia = (id: number) => {
  router.push(`/pages/prosucumbencia/?instancia=${id}`);
};
const EditarCellProSucumbencia = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaProSucumbencia(props.dataItem.id)}><span title='Editar Pro Sucumbencia'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaTribunal = (id: number) => {
  router.push(`/pages/tribunal/?instancia=${id}`);
};
const EditarCellTribunal = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaTribunal(props.dataItem.id)}><span title='Editar Tribunal'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
return (
<>
<Grid
data={sortedFilteredData.slice(page.skip, page.skip + page.take)}
skip={page.skip}
take={page.take}
total={sortedFilteredData.length}
pageable={{
  pageSizes: Array.from(CRUD_CONSTANTS.PAGINATION.PAGE_SIZES), 
  buttonCount: CRUD_CONSTANTS.PAGINATION.BUTTON_COUNT, 
}}
onPageChange={handlePageChange}
sortable={true}
sort={sort}
onSortChange={handleSortChange}
resizable={true}
reorderable={true}
filterable={true}
onFilterChange={handleFilterChange}
onRowClick={(e) => handleRowClick(e)}>
<GridColumn field='index' title='#' sortable={false} filterable={false} width='55px' cells={{ data: RowNumberCell }} />
<GridColumn field='nroprocesso' title='NroProcesso' />
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='N E Notas'
cells={{ data: EditarCellNENotas }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Pro Sucumbencia'
cells={{ data: EditarCellProSucumbencia }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Tribunal'
cells={{ data: EditarCellTribunal }}
/>
</Grid>

</>
);
}
);
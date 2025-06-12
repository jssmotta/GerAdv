// GridsMobile.tsx.txt
'use client';
import React from 'react';
import { Grid, GridColumn, GridFilterChangeEvent, GridPageChangeEvent, GridSortChangeEvent } from '@progress/kendo-react-grid';
import { IForo } from '../../Interfaces/interface.Foro';
import { useRouter } from 'next/navigation';
import { useEffect, useState, useMemo } from 'react';
import { applyFilter, applyFilterToColumn, CRUD_CONSTANTS, sortData } from '@/app/tools/crud';
import { SvgIcon } from '@progress/kendo-react-common';
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';
interface ForoGridProps {
  data: IForo[];
  onRowClick: (foro: IForo) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const ForoGridMobileComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: ForoGridProps) => {
const router = useRouter();
const [initialized, setInitialized] = useState(false);
const RowNumberCell = (props: any) => <td>{props.dataIndex + 1}</td>;
const [page, setPage] = useState({
  skip: 0, 
  take: 10, 
});
const [sort, setSort] = useState<any[]>([]);
const [columnFilters, setColumnFilters] = useState({
  nome: ''
});
const handleSortChange = (e: GridSortChangeEvent) => {
  setSort(e.sort);
};
const filteredData = useMemo(() => { return data.filter((data: any) => {
  const nomeMatches = applyFilter(data, 'nome', columnFilters.nome);
  return nomeMatches;
});
}, [data, columnFilters]);
const handleFilterChange = (event: GridFilterChangeEvent) => {
  const filters = event.filter?.filters || [];
  const newColumnFilters = { nome: '' };
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

const openConsultaAgendaRecords = (id: number) => {
  router.push(`/pages/agendarecords/?foro=${id}`);
};
const EditarCellAgendaRecords = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaAgendaRecords(props.dataItem.id)}><span title='Editar Agenda Records'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaDivisaoTribunal = (id: number) => {
  router.push(`/pages/divisaotribunal/?foro=${id}`);
};
const EditarCellDivisaoTribunal = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaDivisaoTribunal(props.dataItem.id)}><span title='Editar Divisao Tribunal'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaInstancia = (id: number) => {
  router.push(`/pages/instancia/?foro=${id}`);
};
const EditarCellInstancia = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaInstancia(props.dataItem.id)}><span title='Editar Instancia'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaPoderJudiciarioAssociado = (id: number) => {
  router.push(`/pages/poderjudiciarioassociado/?foro=${id}`);
};
const EditarCellPoderJudiciarioAssociado = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaPoderJudiciarioAssociado(props.dataItem.id)}><span title='Editar Poder Judiciario Associado'><SvgIcon icon={pencilIcon} /></span></div>
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
<GridColumn field='nome' title='Nome' />
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Agenda Records'
cells={{ data: EditarCellAgendaRecords }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Divisao Tribunal'
cells={{ data: EditarCellDivisaoTribunal }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Instancia'
cells={{ data: EditarCellInstancia }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Poder Judiciario Associado'
cells={{ data: EditarCellPoderJudiciarioAssociado }}
/>
</Grid>

</>
);
}
);
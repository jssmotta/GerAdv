// GridsMobile.tsx
'use client';
import React from 'react';
import { Grid, GridColumn } from '@progress/kendo-react-grid';
import { IAgenda } from '../../Interfaces/interface.Agenda';
import { useRouter } from 'next/navigation';
import { useMemo, useCallback } from 'react';
import { applyFilter, CRUD_CONSTANTS } from '@/app/tools/crud';
import { SvgIcon } from '@progress/kendo-react-common';
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';
import { useGridFilter } from '@/app/hooks/useGridFilter';
import { useGridSort } from '@/app/hooks/useGridSort';
import { useGridPagination } from '@/app/hooks/useGridPagination';
interface AgendaGridProps {
  data: IAgenda[];
  onRowClick: (agenda: IAgenda) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const AgendaGridMobileComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: AgendaGridProps) => {
const router = useRouter();

const RowNumberCell = (props: any) => <td>{props.dataIndex + 1}</td>;
// Hook para paginação
const { page, handlePageChange } = useGridPagination({
  initialSkip: 0, 
  initialTake: 10, 
});
// Configuração dos filtros iniciais
const initialFilters = {

};
// Lógica de filtro customizada usando useCallback
const filterLogic = useCallback((data: IAgenda, filters: Record<string, any>) => {

  return true;
}, []);
// Hook para filtros
const { columnFilters, filteredData, handleFilterChange } = useGridFilter({
  data, 
  initialFilters, 
  filterLogic, 
});
// Hook para ordenação
const { sort, sortedData, handleSortChange } = useGridSort({
  data: filteredData, 
});
const handleRowClick = (e: any) => {
  onRowClick(e.dataItem);
};

const openConsultaAgenda2Agenda = (id: number) => {
  router.push(`/pages/agenda2agenda/?agenda=${id}`);
};
const EditarCellAgenda2Agenda = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaAgenda2Agenda(props.dataItem.id)}><span title='Editar Agenda2 Agenda'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaAgendaRecords = (id: number) => {
  router.push(`/pages/agendarecords/?agenda=${id}`);
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
const openConsultaAgendaStatus = (id: number) => {
  router.push(`/pages/agendastatus/?agenda=${id}`);
};
const EditarCellAgendaStatus = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaAgendaStatus(props.dataItem.id)}><span title='Editar Agenda Status'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaAlarmSMS = (id: number) => {
  router.push(`/pages/alarmsms/?agenda=${id}`);
};
const EditarCellAlarmSMS = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaAlarmSMS(props.dataItem.id)}><span title='Editar Alarm S M S'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaRecados = (id: number) => {
  router.push(`/pages/recados/?agenda=${id}`);
};
const EditarCellRecados = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaRecados(props.dataItem.id)}><span title='Editar Recados'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const gridColumns = useMemo(() => [
  <GridColumn field='index' title='#' sortable={false} filterable={false} width='55px' cells={{ data: RowNumberCell }} />,
  <GridColumn field='data' title='Data' />,
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Agenda2 Agenda'
  cells={{ data: EditarCellAgenda2Agenda }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Agenda Records'
  cells={{ data: EditarCellAgendaRecords }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Agenda Status'
  cells={{ data: EditarCellAgendaStatus }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Alarm S M S'
  cells={{ data: EditarCellAlarmSMS }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Recados'
  cells={{ data: EditarCellRecados }}
  />, 
  ], []);
  const ExcluirLinha = (e: any) => {
    return (
    <td>
      <span onClick={() => onDeleteClick(e) } title='Excluit item' ><SvgIcon icon={trashIcon} /></span>
    </td>
  );
};
return (
<>
<Grid
className='grid-mobile-agenda'
data={sortedData.slice(page.skip, page.skip + page.take)}
skip={page.skip}
take={page.take}
total={sortedData.length}
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
{gridColumns}
</Grid>
</>
);
}
);
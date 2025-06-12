// GridsDesktop.tsx.txt
'use client';
import React from 'react';
import { Grid, GridColumn, GridFilterChangeEvent, GridPageChangeEvent, GridSortChangeEvent } from '@progress/kendo-react-grid';
import { IAgenda } from '../../Interfaces/interface.Agenda';
import { useRouter } from 'next/navigation';
import { useEffect, useState, useMemo } from 'react';
import { applyFilter, applyFilterToColumn, CRUD_CONSTANTS, sortData } from '@/app/tools/crud';
import { SvgIcon } from '@progress/kendo-react-common';
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';
interface AgendaGridProps {
  data: IAgenda[];
  onRowClick: (agenda: IAgenda) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const AgendaGridDesktopComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: AgendaGridProps) => {
const router = useRouter();
const [initialized, setInitialized] = useState(false);
const RowNumberCell = (props: any) => <td>{props.dataIndex + 1}</td>;
const [page, setPage] = useState({
  skip: 0, 
  take: 10, 
});
const [sort, setSort] = useState<any[]>([]);
const [columnFilters, setColumnFilters] = useState({

});
const handleSortChange = (e: GridSortChangeEvent) => {
  setSort(e.sort);
};
const filteredData = useMemo(() => {
  return data.filter((data: any) => {

    return data;
  });
}, [data, columnFilters]);
const handleFilterChange = (event: GridFilterChangeEvent) => {
  const filters = event.filter?.filters || [];
  const newColumnFilters = {
  };
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
onRowDoubleClick={(e) => handleRowClick(e)}>
<GridColumn field='index' title='#' sortable={false} filterable={false} width='55px' cells={{ data: RowNumberCell }} />

<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Agenda2 Agenda'
cells={{ data: EditarCellAgenda2Agenda }}
/>
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
title='Agenda Status'
cells={{ data: EditarCellAgendaStatus }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Alarm S M S'
cells={{ data: EditarCellAlarmSMS }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Recados'
cells={{ data: EditarCellRecados }}
/>
<GridColumn field='nomecidade' title='Cidade' sortable={false} filterable={false} /> {/* Track G.01 */}

<GridColumn field='nomeadvogados' title='Advogados' sortable={false} filterable={false} /> {/* Track G.01 */}

<GridColumn field='nomefuncionarios' title='Colaborador' sortable={false} filterable={false} /> {/* Track G.01 */}

<GridColumn field='descricaotipocompromisso' title='Tipo Compromisso' sortable={false} filterable={false} /> {/* Track G.01 */}

<GridColumn field='nomeclientes' title='Clientes' sortable={false} filterable={false} /> {/* Track G.01 */}

<GridColumn field='descricaoarea' title='Area' sortable={false} filterable={false} /> {/* Track G.01 */}

<GridColumn field='nomejustica' title='Justica' sortable={false} filterable={false} /> {/* Track G.01 */}

<GridColumn field='nropastaprocessos' title='Processos' sortable={false} filterable={false} /> {/* Track G.01 */}

<GridColumn field='rnomeoperador' title='Operador' sortable={false} filterable={false} /> {/* Track G.01 */}

<GridColumn field='nomeprepostos' title='Prepostos' sortable={false} filterable={false} /> {/* Track G.01 */}
<GridColumn
field='id'
width={'55px'}
title='Excluir'
sortable={false} filterable={false}
cells={{ data: ExcluirLinha }} />
</Grid>

</>
);
}
);
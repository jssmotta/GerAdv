// GridsMobile.tsx.txt
'use client';
import React from 'react';
import { Grid, GridColumn, GridFilterChangeEvent, GridPageChangeEvent, GridSortChangeEvent } from '@progress/kendo-react-grid';
import { ICargos } from '../../Interfaces/interface.Cargos';
import { useRouter } from 'next/navigation';
import { useEffect, useState, useMemo } from 'react';
import { applyFilter, applyFilterToColumn, CRUD_CONSTANTS, sortData } from '@/app/tools/crud';
import { SvgIcon } from '@progress/kendo-react-common';
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';
interface CargosGridProps {
  data: ICargos[];
  onRowClick: (cargos: ICargos) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const CargosGridMobileComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: CargosGridProps) => {
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

const openConsultaAdvogados = (id: number) => {
  router.push(`/pages/advogados/?cargos=${id}`);
};
const EditarCellAdvogados = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaAdvogados(props.dataItem.id)}><span title='Editar Advogados'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaColaboradores = (id: number) => {
  router.push(`/pages/colaboradores/?cargos=${id}`);
};
const EditarCellColaboradores = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaColaboradores(props.dataItem.id)}><span title='Editar Colaboradores'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaFuncionarios = (id: number) => {
  router.push(`/pages/funcionarios/?cargos=${id}`);
};
const EditarCellFuncionarios = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaFuncionarios(props.dataItem.id)}><span title='Editar Colaborador'><SvgIcon icon={pencilIcon} /></span></div>
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
title='Advogados'
cells={{ data: EditarCellAdvogados }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Colaboradores'
cells={{ data: EditarCellColaboradores }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Colaborador'
cells={{ data: EditarCellFuncionarios }}
/>
</Grid>

</>
);
}
);
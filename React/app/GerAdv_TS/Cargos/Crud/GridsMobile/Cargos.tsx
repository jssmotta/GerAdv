// GridsMobile.tsx
'use client';
import React from 'react';
import { Grid, GridColumn } from '@progress/kendo-react-grid';
import { ICargos } from '../../Interfaces/interface.Cargos';
import { useRouter } from 'next/navigation';
import { useMemo, useCallback } from 'react';
import { applyFilter, CRUD_CONSTANTS } from '@/app/tools/crud';
import { SvgIcon } from '@progress/kendo-react-common';
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';
import { useGridFilter } from '@/app/hooks/useGridFilter';
import { useGridSort } from '@/app/hooks/useGridSort';
import { useGridPagination } from '@/app/hooks/useGridPagination';
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

const RowNumberCell = (props: any) => <td>{props.dataIndex + 1}</td>;
// Hook para paginação
const { page, handlePageChange } = useGridPagination({
  initialSkip: 0, 
  initialTake: 10, 
});
// Configuração dos filtros iniciais
const initialFilters = {
  nome: '',
};
// Lógica de filtro customizada usando useCallback
const filterLogic = useCallback((data: ICargos, filters: Record<string, any>) => {
  const nomeMatches = applyFilter(data, 'nome', filters.nome);
  return nomeMatches
  ;
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
const gridColumns = useMemo(() => [
  <GridColumn field='index' title='#' sortable={false} filterable={false} width='55px' cells={{ data: RowNumberCell }} />,
  <GridColumn field='nome' title='Nome' />,
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Advogados'
  cells={{ data: EditarCellAdvogados }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Colaboradores'
  cells={{ data: EditarCellColaboradores }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='Colaborador'
  cells={{ data: EditarCellFuncionarios }}
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
className='grid-mobile-cargos'
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
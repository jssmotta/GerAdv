// GridsMobile.tsx
'use client';
import React from 'react';
import { Grid, GridColumn } from '@progress/kendo-react-grid';
import { IGUTAtividades } from '../../Interfaces/interface.GUTAtividades';
import { useRouter } from 'next/navigation';
import { useMemo, useCallback } from 'react';
import { applyFilter, CRUD_CONSTANTS } from '@/app/tools/crud';
import { SvgIcon } from '@progress/kendo-react-common';
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';
import { useGridFilter } from '@/app/hooks/useGridFilter';
import { useGridSort } from '@/app/hooks/useGridSort';
import { useGridPagination } from '@/app/hooks/useGridPagination';
interface GUTAtividadesGridProps {
  data: IGUTAtividades[];
  onRowClick: (gutatividades: IGUTAtividades) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const GUTAtividadesGridMobileComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: GUTAtividadesGridProps) => {
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
const filterLogic = useCallback((data: IGUTAtividades, filters: Record<string, any>) => {
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

const openConsultaGUTAtividadesMatriz = (id: number) => {
  router.push(`/pages/gutatividadesmatriz/?gutatividades=${id}`);
};
const EditarCellGUTAtividadesMatriz = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaGUTAtividadesMatriz(props.dataItem.id)}><span title='Editar G U T Atividades Matriz'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaGUTPeriodicidadeStatus = (id: number) => {
  router.push(`/pages/gutperiodicidadestatus/?gutatividades=${id}`);
};
const EditarCellGUTPeriodicidadeStatus = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaGUTPeriodicidadeStatus(props.dataItem.id)}><span title='Editar G U T Periodicidade Status'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const MaskagtMinutosParaRealizarCell = (props: any) => {
  const valor = props.dataItem[props.field];
  const formattedValue = valor ? valor.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' }) : 'R$ 0,00';
  return <td>{formattedValue}</td>;
};
const gridColumns = useMemo(() => [
  <GridColumn field='index' title='#' sortable={false} filterable={false} width='55px' cells={{ data: RowNumberCell }} />,
  <GridColumn field='nome' title='Nome' />,
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='G U T Atividades Matriz'
  cells={{ data: EditarCellGUTAtividadesMatriz }}
  />, 
  <GridColumn
  field='id'
  filterable={false}
  sortable={false}
  width={'65px'}
  title='G U T Periodicidade Status'
  cells={{ data: EditarCellGUTPeriodicidadeStatus }}
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
className='grid-mobile-gutatividades'
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
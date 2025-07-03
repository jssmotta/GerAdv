// GridsMobile.tsx
'use client';
import React from 'react';
import { Grid, GridColumn } from '@progress/kendo-react-grid';
import { IAlertas } from '../../Interfaces/interface.Alertas';
import { useRouter } from 'next/navigation';
import { useMemo, useCallback } from 'react';
import { applyFilter, CRUD_CONSTANTS } from '@/app/tools/crud';
import { SvgIcon } from '@progress/kendo-react-common';
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';
import { useGridFilter } from '@/app/hooks/useGridFilter';
import { useGridSort } from '@/app/hooks/useGridSort';
import { useGridPagination } from '@/app/hooks/useGridPagination';
interface AlertasGridProps {
  data: IAlertas[];
  onRowClick: (alertas: IAlertas) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const AlertasGridMobileComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: AlertasGridProps) => {
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
const filterLogic = useCallback((data: IAlertas, filters: Record<string, any>) => {
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

const openConsultaAlertasEnviados = (id: number) => {
  router.push(`/pages/alertasenviados/?alertas=${id}`);
};
const EditarCellAlertasEnviados = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaAlertasEnviados(props.dataItem.id)}><span title='Editar Alertas Enviados'><SvgIcon icon={pencilIcon} /></span></div>
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
  title='Alertas Enviados'
  cells={{ data: EditarCellAlertasEnviados }}
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
className='grid-mobile-alertas'
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
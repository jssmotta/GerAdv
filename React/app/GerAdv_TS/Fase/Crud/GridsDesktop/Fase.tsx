// GridsDesktop.tsx.txt
'use client';
import React from 'react';
import { Grid, GridColumn, GridFilterChangeEvent, GridPageChangeEvent, GridSortChangeEvent } from '@progress/kendo-react-grid';
import { IFase } from '../../Interfaces/interface.Fase';
import { useRouter } from 'next/navigation';
import { useEffect, useState, useMemo } from 'react';
import { applyFilter, applyFilterToColumn, CRUD_CONSTANTS, sortData } from '@/app/tools/crud';
import { SvgIcon } from '@progress/kendo-react-common';
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';
interface FaseGridProps {
  data: IFase[];
  onRowClick: (fase: IFase) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const FaseGridDesktopComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: FaseGridProps) => {
const router = useRouter();
const [initialized, setInitialized] = useState(false);
const RowNumberCell = (props: any) => <td>{props.dataIndex + 1}</td>;
const [page, setPage] = useState({
  skip: 0, 
  take: 10, 
});
const [sort, setSort] = useState<any[]>([]);
const [columnFilters, setColumnFilters] = useState({
  descricao: '',
});
const handleSortChange = (e: GridSortChangeEvent) => {
  setSort(e.sort);
};
const filteredData = useMemo(() => {
  return data.filter((data: any) => {
    const descricaoMatches = applyFilter(data, 'descricao', columnFilters.descricao);
    return descricaoMatches
    ;
  });
}, [data, columnFilters]);
const handleFilterChange = (event: GridFilterChangeEvent) => {
  const filters = event.filter?.filters || [];
  const newColumnFilters = { descricao: '',
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

const openConsultaHistorico = (id: number) => {
  router.push(`/pages/historico/?fase=${id}`);
};
const EditarCellHistorico = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaHistorico(props.dataItem.id)}><span title='Editar Historico'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaProDepositos = (id: number) => {
  router.push(`/pages/prodepositos/?fase=${id}`);
};
const EditarCellProDepositos = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaProDepositos(props.dataItem.id)}><span title='Editar Pro Depositos'><SvgIcon icon={pencilIcon} /></span></div>
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

<GridColumn field='descricao' title='Descricao' sortable={true} filterable={true} />  {/* Track G.02 */}
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Historico'
cells={{ data: EditarCellHistorico }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Pro Depositos'
cells={{ data: EditarCellProDepositos }}
/>
<GridColumn field='nomejustica' title='Justica' sortable={false} filterable={false} /> {/* Track G.01 */}

<GridColumn field='descricaoarea' title='Area' sortable={false} filterable={false} /> {/* Track G.01 */}
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
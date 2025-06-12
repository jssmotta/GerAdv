// GridsMobile.tsx.txt
'use client';
import React from 'react';
import { Grid, GridColumn, GridFilterChangeEvent, GridPageChangeEvent, GridSortChangeEvent } from '@progress/kendo-react-grid';
import { IContatoCRM } from '../../Interfaces/interface.ContatoCRM';
import { useRouter } from 'next/navigation';
import { useEffect, useState, useMemo } from 'react';
import { applyFilter, applyFilterToColumn, CRUD_CONSTANTS, sortData } from '@/app/tools/crud';
import { SvgIcon } from '@progress/kendo-react-common';
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';
interface ContatoCRMGridProps {
  data: IContatoCRM[];
  onRowClick: (contatocrm: IContatoCRM) => void;
  onDeleteClick: (e: any) => void;
  setSelectedId: (id: number | null) => void;
}
export const ContatoCRMGridMobileComponent = React.memo(
({
  data, 
  onRowClick, 
  onDeleteClick, 
  setSelectedId, 

}: ContatoCRMGridProps) => {
const router = useRouter();
const [initialized, setInitialized] = useState(false);
const RowNumberCell = (props: any) => <td>{props.dataIndex + 1}</td>;
const [page, setPage] = useState({
  skip: 0, 
  take: 10, 
});
const [sort, setSort] = useState<any[]>([]);
const [columnFilters, setColumnFilters] = useState({
  : ''
});
const handleSortChange = (e: GridSortChangeEvent) => {
  setSort(e.sort);
};
const filteredData = useMemo(() => { return data.filter((data: any) => {
  const Matches = applyFilter(data, '', columnFilters.);
  return Matches;
});
}, [data, columnFilters]);
const handleFilterChange = (event: GridFilterChangeEvent) => {
  const filters = event.filter?.filters || [];
  const newColumnFilters = { : '' };
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

const openConsultaContatoCRMOperador = (id: number) => {
  router.push(`/pages/contatocrmoperador/?contatocrm=${id}`);
};
const EditarCellContatoCRMOperador = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaContatoCRMOperador(props.dataItem.id)}><span title='Editar Contato C R M Operador'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaDocsRecebidosItens = (id: number) => {
  router.push(`/pages/docsrecebidositens/?contatocrm=${id}`);
};
const EditarCellDocsRecebidosItens = (props: any) => {
  return (
  <>
  <td>
    <div onClick={() => openConsultaDocsRecebidosItens(props.dataItem.id)}><span title='Editar Docs Recebidos Itens'><SvgIcon icon={pencilIcon} /></span></div>
  </td>
</>
);
};
const openConsultaRecados = (id: number) => {
  router.push(`/pages/recados/?contatocrm=${id}`);
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
<GridColumn field='' title='' />
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Contato C R M Operador'
cells={{ data: EditarCellContatoCRMOperador }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Docs Recebidos Itens'
cells={{ data: EditarCellDocsRecebidosItens }}
/>
<GridColumn
field='id'
filterable={false}
sortable={false}
width={'65px'}
title='Recados'
cells={{ data: EditarCellRecados }}
/>
</Grid>

</>
);
}
);
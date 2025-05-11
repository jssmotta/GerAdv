// GridsMobile.tsx.txt
"use client";
import { Grid, GridColumn, GridFilterChangeEvent, GridPageChangeEvent, GridSortChangeEvent } from "@progress/kendo-react-all";
import { IHistorico } from "../../Interfaces/interface.Historico";
import { useRouter } from 'next/navigation';
import { LoaderGrid } from "@/app/components/Cruds/GridLoader";
import { useState } from "react";
import { applyFilter, applyFilterToColumn, sortData } from "@/app/tools/crud";
import { SvgIcon } from "@progress/kendo-react-common";
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';

interface HistoricoGridProps {
	data: IHistorico[];
	onRowClick: (historico: IHistorico) => void;
	onDeleteClick: (e: any) => void;
	setSelectedId: (id: number | null) => void;
}

export const HistoricoGridMobileComponent: React.FC<HistoricoGridProps> = ({
	data,
	onRowClick,
	onDeleteClick,
	setSelectedId,
}) => {
	const router = useRouter();

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
	const filteredData = data.filter((data: any) => {
		const Matches = applyFilter(data, '', columnFilters.);

		return Matches;
	});

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

const openConsultaProcessosObsReport = (id: number) => {     
    router.push(`/pages/processosobsreport/?historico=${id}`);    
};

const EditarCellProcessosObsReport = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaProcessosObsReport(props.dataItem.id)}><span title='Editar Processos Obs Report'><SvgIcon icon={pencilIcon} /></span></div>
        </td>
      </>
    );
}; 
const openConsultaRecados = (id: number) => {     
    router.push(`/pages/recados/?historico=${id}`);    
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
					pageSizes: [10, 15, 30, 50, 100],
					buttonCount: 5,
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
				<GridColumn field="index" title="#" sortable={false} filterable={false} width="55px" cells={{ data: RowNumberCell }} />
				<GridColumn field="" title="" />
				 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Processos Obs Report"
        cells={{ data: EditarCellProcessosObsReport }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Recados"
        cells={{ data: EditarCellRecados }}
      />

			</Grid>
			{!data && (<LoaderGrid />)}
		</>
	);

};

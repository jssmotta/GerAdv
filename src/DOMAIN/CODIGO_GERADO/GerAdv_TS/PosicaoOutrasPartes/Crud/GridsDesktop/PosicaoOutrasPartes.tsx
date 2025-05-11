// GridsDesktop.tsx.txt
"use client";
import { Grid, GridColumn, GridFilterChangeEvent, GridPageChangeEvent, GridSortChangeEvent } from "@progress/kendo-react-all";
import { IPosicaoOutrasPartes } from "../../Interfaces/interface.PosicaoOutrasPartes";
import { useRouter } from 'next/navigation';
import { LoaderGrid } from "@/app/components/Cruds/GridLoader";
import { useState } from "react";
import { applyFilter, applyFilterToColumn, sortData } from "@/app/tools/crud";
import { SvgIcon } from "@progress/kendo-react-common";
import { pencilIcon, trashIcon } from '@progress/kendo-svg-icons';

interface PosicaoOutrasPartesGridProps {
	data: IPosicaoOutrasPartes[];
	onRowClick: (posicaooutraspartes: IPosicaoOutrasPartes) => void;
	onDeleteClick: (e: any) => void;
	setSelectedId: (id: number | null) => void;
}

export const PosicaoOutrasPartesGridDesktopComponent: React.FC<PosicaoOutrasPartesGridProps> = ({
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
		descricao: '',

	});

	const handleSortChange = (e: GridSortChangeEvent) => {
		setSort(e.sort);
	};
	const filteredData = data.filter((data: any) => {
		const descricaoMatches = applyFilter(data, 'descricao', columnFilters.descricao);

		return descricaoMatches
;
	});

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

const openConsultaTerceiros = (id: number) => {     
    router.push(`/pages/terceiros/?posicaooutraspartes=${id}`);    
};

const EditarCellTerceiros = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaTerceiros(props.dataItem.id)}><span title='Editar Terceiros'><SvgIcon icon={pencilIcon} /></span></div>
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
			
				<GridColumn field="descricao" title="Descricao" sortable={true} filterable={true} />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Terceiros"
        cells={{ data: EditarCellTerceiros }}
      />
<GridColumn 	
			field="id" 
			width={'55px'}
			title="Excluir"
			sortable={false} filterable={false}
			cells={{ data: ExcluirLinha }} />

			</Grid>
			{!data && (<LoaderGrid />)}
		</>
	);

};

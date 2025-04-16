"use client";
import { Grid, GridColumn, GridFilterChangeEvent, GridPageChangeEvent, GridSortChangeEvent } from "@progress/kendo-react-all";
import { IOperadorGruposAgenda } from "../../Interfaces/interface.OperadorGruposAgenda";
import { useRouter } from 'next/navigation';
import { LoaderGrid } from "@/app/components/GridLoader";
import { useState } from "react";
import { applyFilter, applyFilterToColumn, sortData } from "@/app/tools/crud";

interface OperadorGruposAgendaGridProps {
	data: IOperadorGruposAgenda[];
	onRowClick: (operadorgruposagenda: IOperadorGruposAgenda) => void;
	onDeleteClick: (e: any) => void;
}

export const OperadorGruposAgendaGridMobileComponent: React.FC<OperadorGruposAgendaGridProps> = ({
	data,
	onRowClick,
	onDeleteClick
}) => {
	const router = useRouter();

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
	const filteredData = data.filter((data: any) => {
		const nomeMatches = applyFilter(data, 'nome', columnFilters.nome);

		return nomeMatches;
	});

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

const openConsultaOperadorGruposAgendaOperadores = (id: number) => {     
    router.push(`/pages/operadorgruposagendaoperadores/?operadorgruposagenda=${id}`);    
};

const EditarCellOperadorGruposAgendaOperadores = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaOperadorGruposAgendaOperadores(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Operador Grupos Agenda Operadores' />&nbsp;</div>
        </td>
      </>
    );
};	
	
	const ExcluirLinha = (e: any) => {
		return (
			<td>
				
				<img onClick={() => onDeleteClick(e) } src='https://cdn.menphis.com.br/msi/v20/excluir3.webp' alt="Excluir" width="20" height="20" />
				
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
				<GridColumn field="nome" title="Nome" />
				 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Operador Grupos Agenda Operadores"
        cells={{ data: EditarCellOperadorGruposAgendaOperadores }}
      />

			</Grid>
			{!data && (<LoaderGrid />)}
		</>
	);

};

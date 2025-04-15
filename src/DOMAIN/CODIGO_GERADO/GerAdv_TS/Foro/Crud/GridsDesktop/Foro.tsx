"use client";
import { Grid, GridColumn, GridFilterChangeEvent, GridPageChangeEvent, GridSortChangeEvent } from "@progress/kendo-react-all";
import { IForo } from "../../Interfaces/interface.Foro";
import { useRouter } from 'next/navigation';
import { LoaderGrid } from "@/app/components/GridLoader";
import { useState } from "react";
import { applyFilter, applyFilterToColumn, sortData } from "@/app/tools/crud";

interface ForoGridProps {
	data: IForo[];
	onRowClick: (foro: IForo) => void;
	onDeleteClick: (e: any) => void;
}

export const ForoGridDesktopComponent: React.FC<ForoGridProps> = ({
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
		nome: '',

	});

	const handleSortChange = (e: GridSortChangeEvent) => {
		setSort(e.sort);
	};
	const filteredData = data.filter((data: any) => {
		const nomeMatches = applyFilter(data, 'nome', columnFilters.nome);

		return nomeMatches
;
	});

	const handleFilterChange = (event: GridFilterChangeEvent) => {
		const filters = event.filter?.filters || [];
		const newColumnFilters = { nome: '',
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

const openConsultaAgendaRecords = (id: number) => {     
    router.push(`/pages/agendarecords/?foro=${id}`);    
};

const EditarCellAgendaRecords = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaAgendaRecords(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Agenda Records' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaDivisaoTribunal = (id: number) => {     
    router.push(`/pages/divisaotribunal/?foro=${id}`);    
};

const EditarCellDivisaoTribunal = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaDivisaoTribunal(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Divisao Tribunal' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaInstancia = (id: number) => {     
    router.push(`/pages/instancia/?foro=${id}`);    
};

const EditarCellInstancia = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaInstancia(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Instancia' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaPoderJudiciarioAssociado = (id: number) => {     
    router.push(`/pages/poderjudiciarioassociado/?foro=${id}`);    
};

const EditarCellPoderJudiciarioAssociado = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaPoderJudiciarioAssociado(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Poder Judiciario Associado' />&nbsp;</div>
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
			
				<GridColumn field="nome" title="Nome" sortable={true} filterable={true} />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Agenda Records"
        cells={{ data: EditarCellAgendaRecords }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Divisao Tribunal"
        cells={{ data: EditarCellDivisaoTribunal }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Instancia"
        cells={{ data: EditarCellInstancia }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Poder Judiciario Associado"
        cells={{ data: EditarCellPoderJudiciarioAssociado }}
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

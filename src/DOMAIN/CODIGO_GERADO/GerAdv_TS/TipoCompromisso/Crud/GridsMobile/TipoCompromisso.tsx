"use client";
import { Grid, GridColumn, GridFilterChangeEvent, GridPageChangeEvent, GridSortChangeEvent } from "@progress/kendo-react-all";
import { ITipoCompromisso } from "../../Interfaces/interface.TipoCompromisso";
import { useRouter } from 'next/navigation';
import { LoaderGrid } from "@/app/components/GridLoader";
import { useState } from "react";
import { applyFilter, applyFilterToColumn, sortData } from "@/app/tools/crud";

interface TipoCompromissoGridProps {
	data: ITipoCompromisso[];
	onRowClick: (tipocompromisso: ITipoCompromisso) => void;
	onDeleteClick: (e: any) => void;
}

export const TipoCompromissoGridMobileComponent: React.FC<TipoCompromissoGridProps> = ({
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

const openConsultaAgenda = (id: number) => {     
    router.push(`/pages/agenda/?tipocompromisso=${id}`);    
};

const EditarCellAgenda = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaAgenda(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Agenda' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaAgendaFinanceiro = (id: number) => {     
    router.push(`/pages/agendafinanceiro/?tipocompromisso=${id}`);    
};

const EditarCellAgendaFinanceiro = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaAgendaFinanceiro(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Agenda Financeiro' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaNECompromissos = (id: number) => {     
    router.push(`/pages/necompromissos/?tipocompromisso=${id}`);    
};

const EditarCellNECompromissos = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaNECompromissos(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar N E Compromissos' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaAgendaSemana = (id: number) => {     
    router.push(`/pages/agendasemana/?tipocompromisso=${id}`);    
};

const EditarCellAgendaSemana = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaAgendaSemana(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Agenda Semana' />&nbsp;</div>
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
        title="Agenda"
        cells={{ data: EditarCellAgenda }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Agenda Financeiro"
        cells={{ data: EditarCellAgendaFinanceiro }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="N E Compromissos"
        cells={{ data: EditarCellNECompromissos }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Agenda Semana"
        cells={{ data: EditarCellAgendaSemana }}
      />

			</Grid>
			{!data && (<LoaderGrid />)}
		</>
	);

};

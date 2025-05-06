// GridsDesktop.tsx.txt
"use client";
import { Grid, GridColumn, GridFilterChangeEvent, GridPageChangeEvent, GridSortChangeEvent } from "@progress/kendo-react-all";
import { ICidade } from "../../Interfaces/interface.Cidade";
import { useRouter } from 'next/navigation';
import { LoaderGrid } from "@/app/components/Cruds/GridLoader";
import { useState } from "react";
import { applyFilter, applyFilterToColumn, sortData } from "@/app/tools/crud";

interface CidadeGridProps {
	data: ICidade[];
	onRowClick: (cidade: ICidade) => void;
	onDeleteClick: (e: any) => void;
	setSelectedId: (id: number | null) => void;
}

export const CidadeGridDesktopComponent: React.FC<CidadeGridProps> = ({
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

const openConsultaAdvogados = (id: number) => {     
    router.push(`/pages/advogados/?cidade=${id}`);    
};

const EditarCellAdvogados = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaAdvogados(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Advogados' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaAgenda = (id: number) => {     
    router.push(`/pages/agenda/?cidade=${id}`);    
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
    router.push(`/pages/agendafinanceiro/?cidade=${id}`);    
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
const openConsultaBensMateriais = (id: number) => {     
    router.push(`/pages/bensmateriais/?cidade=${id}`);    
};

const EditarCellBensMateriais = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaBensMateriais(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Bens Materiais' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaClientes = (id: number) => {     
    router.push(`/pages/clientes/?cidade=${id}`);    
};

const EditarCellClientes = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaClientes(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Clientes' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaClientesSocios = (id: number) => {     
    router.push(`/pages/clientessocios/?cidade=${id}`);    
};

const EditarCellClientesSocios = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaClientesSocios(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Clientes Socios' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaColaboradores = (id: number) => {     
    router.push(`/pages/colaboradores/?cidade=${id}`);    
};

const EditarCellColaboradores = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaColaboradores(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Colaboradores' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaDivisaoTribunal = (id: number) => {     
    router.push(`/pages/divisaotribunal/?cidade=${id}`);    
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
const openConsultaEnderecos = (id: number) => {     
    router.push(`/pages/enderecos/?cidade=${id}`);    
};

const EditarCellEnderecos = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaEnderecos(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Endereços' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaEnderecoSistema = (id: number) => {     
    router.push(`/pages/enderecosistema/?cidade=${id}`);    
};

const EditarCellEnderecoSistema = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaEnderecoSistema(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Endereco Sistema' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaEscritorios = (id: number) => {     
    router.push(`/pages/escritorios/?cidade=${id}`);    
};

const EditarCellEscritorios = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaEscritorios(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Escritorios' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaFornecedores = (id: number) => {     
    router.push(`/pages/fornecedores/?cidade=${id}`);    
};

const EditarCellFornecedores = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaFornecedores(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Fornecedores' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaForo = (id: number) => {     
    router.push(`/pages/foro/?cidade=${id}`);    
};

const EditarCellForo = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaForo(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Foro' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaFuncionarios = (id: number) => {     
    router.push(`/pages/funcionarios/?cidade=${id}`);    
};

const EditarCellFuncionarios = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaFuncionarios(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Colaborador' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaOponentes = (id: number) => {     
    router.push(`/pages/oponentes/?cidade=${id}`);    
};

const EditarCellOponentes = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaOponentes(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Oponentes' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaOponentesRepLegal = (id: number) => {     
    router.push(`/pages/oponentesreplegal/?cidade=${id}`);    
};

const EditarCellOponentesRepLegal = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaOponentesRepLegal(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Oponentes Rep Legal' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaOutrasPartesCliente = (id: number) => {     
    router.push(`/pages/outraspartescliente/?cidade=${id}`);    
};

const EditarCellOutrasPartesCliente = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaOutrasPartesCliente(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Outras Partes Cliente' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaPoderJudiciarioAssociado = (id: number) => {     
    router.push(`/pages/poderjudiciarioassociado/?cidade=${id}`);    
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
const openConsultaPreClientes = (id: number) => {     
    router.push(`/pages/preclientes/?cidade=${id}`);    
};

const EditarCellPreClientes = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaPreClientes(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Pre Clientes' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaPrepostos = (id: number) => {     
    router.push(`/pages/prepostos/?cidade=${id}`);    
};

const EditarCellPrepostos = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaPrepostos(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Prepostos' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaProcessos = (id: number) => {     
    router.push(`/pages/processos/?cidade=${id}`);    
};

const EditarCellProcessos = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaProcessos(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Processos' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaTerceiros = (id: number) => {     
    router.push(`/pages/terceiros/?cidade=${id}`);    
};

const EditarCellTerceiros = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaTerceiros(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Terceiros' />&nbsp;</div>
        </td>
      </>
    );
}; 
const openConsultaTribEnderecos = (id: number) => {     
    router.push(`/pages/tribenderecos/?cidade=${id}`);    
};

const EditarCellTribEnderecos = (props: any) => {
    return (
      <>
        <td>
            <div onClick={() => openConsultaTribEnderecos(props.dataItem.id)}><img width='16' height='16' src='https://cdn.menphis.com.br/msi/v20/editar.webp' title='Editar Trib Endereços' />&nbsp;</div>
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
        title="Advogados"
        cells={{ data: EditarCellAdvogados }}
      />
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
        title="Bens Materiais"
        cells={{ data: EditarCellBensMateriais }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Clientes"
        cells={{ data: EditarCellClientes }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Clientes Socios"
        cells={{ data: EditarCellClientesSocios }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Colaboradores"
        cells={{ data: EditarCellColaboradores }}
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
        title="Endereços"
        cells={{ data: EditarCellEnderecos }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Endereco Sistema"
        cells={{ data: EditarCellEnderecoSistema }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Escritorios"
        cells={{ data: EditarCellEscritorios }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Fornecedores"
        cells={{ data: EditarCellFornecedores }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Foro"
        cells={{ data: EditarCellForo }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Colaborador"
        cells={{ data: EditarCellFuncionarios }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Oponentes"
        cells={{ data: EditarCellOponentes }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Oponentes Rep Legal"
        cells={{ data: EditarCellOponentesRepLegal }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Outras Partes Cliente"
        cells={{ data: EditarCellOutrasPartesCliente }}
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
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Pre Clientes"
        cells={{ data: EditarCellPreClientes }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Prepostos"
        cells={{ data: EditarCellPrepostos }}
      />
 <GridColumn
        field="id"
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Processos"
        cells={{ data: EditarCellProcessos }}
      />
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
        filterable={false}
        sortable={false}
        width={'65px'}
        title="Trib Endereços"
        cells={{ data: EditarCellTribEnderecos }}
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

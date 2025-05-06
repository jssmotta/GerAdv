"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { EnquadramentoEmpresaGridAdapter } from "@/app/GerAdv_TS/EnquadramentoEmpresa/Adapter/EnquadramentoEmpresaGridAdapter";
import EnquadramentoEmpresaGridContainer from "@/app/GerAdv_TS/EnquadramentoEmpresa/Components/EnquadramentoEmpresaGridContainer";

const EnquadramentoEmpresaPage: React.FC = () => {
    const EnquadramentoEmpresaGrid = new EnquadramentoEmpresaGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Enquadramento Empresa" />
            <EnquadramentoEmpresaGridContainer grid={EnquadramentoEmpresaGrid} />
        </PageLayout>
    );
};

export default EnquadramentoEmpresaPage;
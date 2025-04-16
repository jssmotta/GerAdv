"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { TipoEnderecoGridAdapter } from "@/app/GerAdv_TS/TipoEndereco/Adapter/TipoEnderecoGridAdapter";
import TipoEnderecoGridContainer from "@/app/GerAdv_TS/TipoEndereco/Components/TipoEnderecoGridContainer";

const TipoEnderecoPage: React.FC = () => {
    const TipoEnderecoGrid = new TipoEnderecoGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Tipo Endereco" />
            <TipoEnderecoGridContainer grid={TipoEnderecoGrid} />
        </PageLayout>
    );
};

export default TipoEnderecoPage;
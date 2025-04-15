"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { TipoEnderecoSistemaGridAdapter } from "@/app/GerAdv_TS/TipoEnderecoSistema/Adapter/TipoEnderecoSistemaGridAdapter";
import TipoEnderecoSistemaGridContainer from "@/app/GerAdv_TS/TipoEnderecoSistema/Components/TipoEnderecoSistemaGridContainer";

const TipoEnderecoSistemaPage: React.FC = () => {
    const TipoEnderecoSistemaGrid = new TipoEnderecoSistemaGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Tipo Endereco Sistema" />
            <TipoEnderecoSistemaGridContainer grid={TipoEnderecoSistemaGrid} />
        </PageLayout>
    );
};

export default TipoEnderecoSistemaPage;
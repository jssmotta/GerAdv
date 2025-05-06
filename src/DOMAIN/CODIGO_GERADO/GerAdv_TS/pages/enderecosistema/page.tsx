"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { EnderecoSistemaGridAdapter } from "@/app/GerAdv_TS/EnderecoSistema/Adapter/EnderecoSistemaGridAdapter";
import EnderecoSistemaGridContainer from "@/app/GerAdv_TS/EnderecoSistema/Components/EnderecoSistemaGridContainer";

const EnderecoSistemaPage: React.FC = () => {
    const EnderecoSistemaGrid = new EnderecoSistemaGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Endereco Sistema" />
            <EnderecoSistemaGridContainer grid={EnderecoSistemaGrid} />
        </PageLayout>
    );
};

export default EnderecoSistemaPage;
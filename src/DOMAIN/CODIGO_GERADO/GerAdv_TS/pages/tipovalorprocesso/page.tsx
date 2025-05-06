"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { TipoValorProcessoGridAdapter } from "@/app/GerAdv_TS/TipoValorProcesso/Adapter/TipoValorProcessoGridAdapter";
import TipoValorProcessoGridContainer from "@/app/GerAdv_TS/TipoValorProcesso/Components/TipoValorProcessoGridContainer";

const TipoValorProcessoPage: React.FC = () => {
    const TipoValorProcessoGrid = new TipoValorProcessoGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Tipo Valor Processo" />
            <TipoValorProcessoGridContainer grid={TipoValorProcessoGrid} />
        </PageLayout>
    );
};

export default TipoValorProcessoPage;
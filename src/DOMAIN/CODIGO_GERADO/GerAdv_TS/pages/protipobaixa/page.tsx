"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ProTipoBaixaGridAdapter } from "@/app/GerAdv_TS/ProTipoBaixa/Adapter/ProTipoBaixaGridAdapter";
import ProTipoBaixaGridContainer from "@/app/GerAdv_TS/ProTipoBaixa/Components/ProTipoBaixaGridContainer";

const ProTipoBaixaPage: React.FC = () => {
    const ProTipoBaixaGrid = new ProTipoBaixaGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Pro Tipo Baixa" />
            <ProTipoBaixaGridContainer grid={ProTipoBaixaGrid} />
        </PageLayout>
    );
};

export default ProTipoBaixaPage;
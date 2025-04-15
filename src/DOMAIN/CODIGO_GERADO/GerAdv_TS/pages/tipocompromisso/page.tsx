"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { TipoCompromissoGridAdapter } from "@/app/GerAdv_TS/TipoCompromisso/Adapter/TipoCompromissoGridAdapter";
import TipoCompromissoGridContainer from "@/app/GerAdv_TS/TipoCompromisso/Components/TipoCompromissoGridContainer";

const TipoCompromissoPage: React.FC = () => {
    const TipoCompromissoGrid = new TipoCompromissoGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Tipo Compromisso" />
            <TipoCompromissoGridContainer grid={TipoCompromissoGrid} />
        </PageLayout>
    );
};

export default TipoCompromissoPage;
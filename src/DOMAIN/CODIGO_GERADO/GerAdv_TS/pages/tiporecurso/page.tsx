"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { TipoRecursoGridAdapter } from "@/app/GerAdv_TS/TipoRecurso/Adapter/TipoRecursoGridAdapter";
import TipoRecursoGridContainer from "@/app/GerAdv_TS/TipoRecurso/Components/TipoRecursoGridContainer";

const TipoRecursoPage: React.FC = () => {
    const TipoRecursoGrid = new TipoRecursoGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Tipo Recurso" />
            <TipoRecursoGridContainer grid={TipoRecursoGrid} />
        </PageLayout>
    );
};

export default TipoRecursoPage;
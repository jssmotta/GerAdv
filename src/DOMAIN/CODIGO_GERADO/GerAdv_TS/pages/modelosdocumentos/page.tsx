"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ModelosDocumentosGridAdapter } from "@/app/GerAdv_TS/ModelosDocumentos/Adapter/ModelosDocumentosGridAdapter";
import ModelosDocumentosGridContainer from "@/app/GerAdv_TS/ModelosDocumentos/Components/ModelosDocumentosGridContainer";

const ModelosDocumentosPage: React.FC = () => {
    const ModelosDocumentosGrid = new ModelosDocumentosGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Modelos Documentos" />
            <ModelosDocumentosGridContainer grid={ModelosDocumentosGrid} />
        </PageLayout>
    );
};

export default ModelosDocumentosPage;
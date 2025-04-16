"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { DocumentosGridAdapter } from "@/app/GerAdv_TS/Documentos/Adapter/DocumentosGridAdapter";
import DocumentosGridContainer from "@/app/GerAdv_TS/Documentos/Components/DocumentosGridContainer";

const DocumentosPage: React.FC = () => {
    const DocumentosGrid = new DocumentosGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Documentos" />
            <DocumentosGridContainer grid={DocumentosGrid} />
        </PageLayout>
    );
};

export default DocumentosPage;
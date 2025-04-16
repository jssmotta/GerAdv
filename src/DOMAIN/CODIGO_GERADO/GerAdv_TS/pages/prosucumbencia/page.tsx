"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ProSucumbenciaGridAdapter } from "@/app/GerAdv_TS/ProSucumbencia/Adapter/ProSucumbenciaGridAdapter";
import ProSucumbenciaGridContainer from "@/app/GerAdv_TS/ProSucumbencia/Components/ProSucumbenciaGridContainer";

const ProSucumbenciaPage: React.FC = () => {
    const ProSucumbenciaGrid = new ProSucumbenciaGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Pro Sucumbencia" />
            <ProSucumbenciaGridContainer grid={ProSucumbenciaGrid} />
        </PageLayout>
    );
};

export default ProSucumbenciaPage;
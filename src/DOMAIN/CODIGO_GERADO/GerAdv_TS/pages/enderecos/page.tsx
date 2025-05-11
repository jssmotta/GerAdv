"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { EnderecosGridAdapter } from "@/app/GerAdv_TS/Enderecos/Adapter/EnderecosGridAdapter";
import EnderecosGridContainer from "@/app/GerAdv_TS/Enderecos/Components/EnderecosGridContainer";

const EnderecosPage: React.FC = () => {
    const EnderecosGrid = new EnderecosGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Endereços" />
            <EnderecosGridContainer grid={EnderecosGrid} />
        </PageLayout>
    );
};

export default EnderecosPage;
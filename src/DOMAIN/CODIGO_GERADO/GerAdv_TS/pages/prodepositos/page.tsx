"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ProDepositosGridAdapter } from "@/app/GerAdv_TS/ProDepositos/Adapter/ProDepositosGridAdapter";
import ProDepositosGridContainer from "@/app/GerAdv_TS/ProDepositos/Components/ProDepositosGridContainer";

const ProDepositosPage: React.FC = () => {
    const ProDepositosGrid = new ProDepositosGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Pro Depositos" />
            <ProDepositosGridContainer grid={ProDepositosGrid} />
        </PageLayout>
    );
};

export default ProDepositosPage;
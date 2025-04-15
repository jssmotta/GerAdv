"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { OperadorEMailPopupGridAdapter } from "@/app/GerAdv_TS/OperadorEMailPopup/Adapter/OperadorEMailPopupGridAdapter";
import OperadorEMailPopupGridContainer from "@/app/GerAdv_TS/OperadorEMailPopup/Components/OperadorEMailPopupGridContainer";

const OperadorEMailPopupPage: React.FC = () => {
    const OperadorEMailPopupGrid = new OperadorEMailPopupGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Operador E Mail Popup" />
            <OperadorEMailPopupGridContainer grid={OperadorEMailPopupGrid} />
        </PageLayout>
    );
};

export default OperadorEMailPopupPage;
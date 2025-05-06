import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import ProcessosObsReportInc from "../Inc/ProcessosObsReport";
import { IProcessosObsReport } from "../../Interfaces/interface.ProcessosObsReport";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ProcessosObsReportEmpty } from "@/app/GerAdv_TS/Models/ProcessosObsReport";
import { useWindow } from "@/app/hooks/useWindows";

interface ProcessosObsReportWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedProcessosObsReport?: IProcessosObsReport;
    onSuccess: () => void;
    onError: () => void;
}

const ProcessosObsReportWindow: React.FC<ProcessosObsReportWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedProcessosObsReport,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/processosobsreport/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedProcessosObsReport?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedProcessosObsReport]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedProcessosObsReport?.id ?? 0).toString()}
                >
                    <ProcessosObsReportInc
                        id={selectedProcessosObsReport?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowProcessosObsReport: React.FC<ProcessosObsReportWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ProcessosObsReportWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedProcessosObsReport={ProcessosObsReportEmpty()}>
        </ProcessosObsReportWindow>
    )
};

export default ProcessosObsReportWindow;
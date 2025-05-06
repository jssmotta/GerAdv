import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import ProcessOutPutIDsInc from "../Inc/ProcessOutPutIDs";
import { IProcessOutPutIDs } from "../../Interfaces/interface.ProcessOutPutIDs";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ProcessOutPutIDsEmpty } from "@/app/GerAdv_TS/Models/ProcessOutPutIDs";
import { useWindow } from "@/app/hooks/useWindows";

interface ProcessOutPutIDsWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedProcessOutPutIDs?: IProcessOutPutIDs;
    onSuccess: () => void;
    onError: () => void;
}

const ProcessOutPutIDsWindow: React.FC<ProcessOutPutIDsWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedProcessOutPutIDs,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/processoutputids/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedProcessOutPutIDs?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedProcessOutPutIDs]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedProcessOutPutIDs?.id ?? 0).toString()}
                >
                    <ProcessOutPutIDsInc
                        id={selectedProcessOutPutIDs?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowProcessOutPutIDs: React.FC<ProcessOutPutIDsWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ProcessOutPutIDsWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedProcessOutPutIDs={ProcessOutPutIDsEmpty()}>
        </ProcessOutPutIDsWindow>
    )
};

export default ProcessOutPutIDsWindow;
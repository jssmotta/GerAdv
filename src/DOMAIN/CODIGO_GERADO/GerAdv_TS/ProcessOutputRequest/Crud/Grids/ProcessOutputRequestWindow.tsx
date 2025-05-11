import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import ProcessOutputRequestInc from "../Inc/ProcessOutputRequest";
import { IProcessOutputRequest } from "../../Interfaces/interface.ProcessOutputRequest";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ProcessOutputRequestEmpty } from "@/app/GerAdv_TS/Models/ProcessOutputRequest";
import { useWindow } from "@/app/hooks/useWindows";

interface ProcessOutputRequestWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedProcessOutputRequest?: IProcessOutputRequest;
    onSuccess: () => void;
    onError: () => void;
}

const ProcessOutputRequestWindow: React.FC<ProcessOutputRequestWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedProcessOutputRequest,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/processoutputrequest/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedProcessOutputRequest?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedProcessOutputRequest]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedProcessOutputRequest?.id ?? 0).toString()}
                >
                    <ProcessOutputRequestInc
                        id={selectedProcessOutputRequest?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowProcessOutputRequest: React.FC<ProcessOutputRequestWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ProcessOutputRequestWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedProcessOutputRequest={ProcessOutputRequestEmpty()}>
        </ProcessOutputRequestWindow>
    )
};

export default ProcessOutputRequestWindow;
import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import ProcessOutputSourcesInc from "../Inc/ProcessOutputSources";
import { IProcessOutputSources } from "../../Interfaces/interface.ProcessOutputSources";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ProcessOutputSourcesEmpty } from "@/app/GerAdv_TS/Models/ProcessOutputSources";
import { useWindow } from "@/app/hooks/useWindows";

interface ProcessOutputSourcesWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedProcessOutputSources?: IProcessOutputSources;
    onSuccess: () => void;
    onError: () => void;
}

const ProcessOutputSourcesWindow: React.FC<ProcessOutputSourcesWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedProcessOutputSources,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/processoutputsources/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedProcessOutputSources?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedProcessOutputSources]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedProcessOutputSources?.id ?? 0).toString()}
                >
                    <ProcessOutputSourcesInc
                        id={selectedProcessOutputSources?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowProcessOutputSources: React.FC<ProcessOutputSourcesWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ProcessOutputSourcesWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedProcessOutputSources={ProcessOutputSourcesEmpty()}>
        </ProcessOutputSourcesWindow>
    )
};

export default ProcessOutputSourcesWindow;
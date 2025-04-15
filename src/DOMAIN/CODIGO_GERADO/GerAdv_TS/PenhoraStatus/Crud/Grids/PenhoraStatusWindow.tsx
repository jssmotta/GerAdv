import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import PenhoraStatusInc from "../Inc/PenhoraStatus";
import { IPenhoraStatus } from "../../Interfaces/interface.PenhoraStatus";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { PenhoraStatusEmpty } from "@/app/GerAdv_TS/Models/PenhoraStatus";
import { useWindow } from "@/app/hooks/useWindows";

interface PenhoraStatusWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedPenhoraStatus?: IPenhoraStatus;
    onSuccess: () => void;
    onError: () => void;
}

const PenhoraStatusWindow: React.FC<PenhoraStatusWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedPenhoraStatus,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/penhorastatus/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedPenhoraStatus?.id}`);
        }

    }, [isMobile, router, selectedPenhoraStatus]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedPenhoraStatus?.id ?? 0).toString()}
                >
                    <PenhoraStatusInc
                        id={selectedPenhoraStatus?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowPenhoraStatus: React.FC<PenhoraStatusWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <PenhoraStatusWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedPenhoraStatus={PenhoraStatusEmpty()}>
        </PenhoraStatusWindow>
    )
};

export default PenhoraStatusWindow;
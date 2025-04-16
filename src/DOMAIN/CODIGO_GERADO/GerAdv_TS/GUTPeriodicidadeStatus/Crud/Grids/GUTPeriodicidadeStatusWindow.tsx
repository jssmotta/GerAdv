import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import GUTPeriodicidadeStatusInc from "../Inc/GUTPeriodicidadeStatus";
import { IGUTPeriodicidadeStatus } from "../../Interfaces/interface.GUTPeriodicidadeStatus";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { GUTPeriodicidadeStatusEmpty } from "@/app/GerAdv_TS/Models/GUTPeriodicidadeStatus";
import { useWindow } from "@/app/hooks/useWindows";

interface GUTPeriodicidadeStatusWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedGUTPeriodicidadeStatus?: IGUTPeriodicidadeStatus;
    onSuccess: () => void;
    onError: () => void;
}

const GUTPeriodicidadeStatusWindow: React.FC<GUTPeriodicidadeStatusWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedGUTPeriodicidadeStatus,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/gutperiodicidadestatus/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedGUTPeriodicidadeStatus?.id}`);
        }

    }, [isMobile, router, selectedGUTPeriodicidadeStatus]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedGUTPeriodicidadeStatus?.id ?? 0).toString()}
                >
                    <GUTPeriodicidadeStatusInc
                        id={selectedGUTPeriodicidadeStatus?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowGUTPeriodicidadeStatus: React.FC<GUTPeriodicidadeStatusWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <GUTPeriodicidadeStatusWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedGUTPeriodicidadeStatus={GUTPeriodicidadeStatusEmpty()}>
        </GUTPeriodicidadeStatusWindow>
    )
};

export default GUTPeriodicidadeStatusWindow;
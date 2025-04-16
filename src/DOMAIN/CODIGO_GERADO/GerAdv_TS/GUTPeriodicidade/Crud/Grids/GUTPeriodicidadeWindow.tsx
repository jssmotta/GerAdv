import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import GUTPeriodicidadeInc from "../Inc/GUTPeriodicidade";
import { IGUTPeriodicidade } from "../../Interfaces/interface.GUTPeriodicidade";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { GUTPeriodicidadeEmpty } from "@/app/GerAdv_TS/Models/GUTPeriodicidade";
import { useWindow } from "@/app/hooks/useWindows";

interface GUTPeriodicidadeWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedGUTPeriodicidade?: IGUTPeriodicidade;
    onSuccess: () => void;
    onError: () => void;
}

const GUTPeriodicidadeWindow: React.FC<GUTPeriodicidadeWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedGUTPeriodicidade,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/gutperiodicidade/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedGUTPeriodicidade?.id}`);
        }

    }, [isMobile, router, selectedGUTPeriodicidade]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedGUTPeriodicidade?.id ?? 0).toString()}
                >
                    <GUTPeriodicidadeInc
                        id={selectedGUTPeriodicidade?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowGUTPeriodicidade: React.FC<GUTPeriodicidadeWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <GUTPeriodicidadeWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedGUTPeriodicidade={GUTPeriodicidadeEmpty()}>
        </GUTPeriodicidadeWindow>
    )
};

export default GUTPeriodicidadeWindow;
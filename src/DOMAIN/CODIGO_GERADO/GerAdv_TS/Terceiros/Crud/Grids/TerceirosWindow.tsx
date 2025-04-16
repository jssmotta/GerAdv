import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import TerceirosInc from "../Inc/Terceiros";
import { ITerceiros } from "../../Interfaces/interface.Terceiros";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { TerceirosEmpty } from "@/app/GerAdv_TS/Models/Terceiros";
import { useWindow } from "@/app/hooks/useWindows";

interface TerceirosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedTerceiros?: ITerceiros;
    onSuccess: () => void;
    onError: () => void;
}

const TerceirosWindow: React.FC<TerceirosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedTerceiros,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/terceiros/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedTerceiros?.id}`);
        }

    }, [isMobile, router, selectedTerceiros]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={641}
                    newWidth={1440}
                    id={(selectedTerceiros?.id ?? 0).toString()}
                >
                    <TerceirosInc
                        id={selectedTerceiros?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowTerceiros: React.FC<TerceirosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <TerceirosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedTerceiros={TerceirosEmpty()}>
        </TerceirosWindow>
    )
};

export default TerceirosWindow;
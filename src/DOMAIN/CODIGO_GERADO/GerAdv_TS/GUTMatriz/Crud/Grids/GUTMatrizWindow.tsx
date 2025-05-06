import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import GUTMatrizInc from "../Inc/GUTMatriz";
import { IGUTMatriz } from "../../Interfaces/interface.GUTMatriz";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { GUTMatrizEmpty } from "@/app/GerAdv_TS/Models/GUTMatriz";
import { useWindow } from "@/app/hooks/useWindows";

interface GUTMatrizWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedGUTMatriz?: IGUTMatriz;
    onSuccess: () => void;
    onError: () => void;
}

const GUTMatrizWindow: React.FC<GUTMatrizWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedGUTMatriz,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/gutmatriz/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedGUTMatriz?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedGUTMatriz]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedGUTMatriz?.id ?? 0).toString()}
                >
                    <GUTMatrizInc
                        id={selectedGUTMatriz?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowGUTMatriz: React.FC<GUTMatrizWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <GUTMatrizWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedGUTMatriz={GUTMatrizEmpty()}>
        </GUTMatrizWindow>
    )
};

export default GUTMatrizWindow;
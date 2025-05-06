import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import GUTAtividadesInc from "../Inc/GUTAtividades";
import { IGUTAtividades } from "../../Interfaces/interface.GUTAtividades";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { GUTAtividadesEmpty } from "@/app/GerAdv_TS/Models/GUTAtividades";
import { useWindow } from "@/app/hooks/useWindows";

interface GUTAtividadesWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedGUTAtividades?: IGUTAtividades;
    onSuccess: () => void;
    onError: () => void;
}

const GUTAtividadesWindow: React.FC<GUTAtividadesWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedGUTAtividades,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/gutatividades/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedGUTAtividades?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedGUTAtividades]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={791}
                    newWidth={720}
                    id={(selectedGUTAtividades?.id ?? 0).toString()}
                >
                    <GUTAtividadesInc
                        id={selectedGUTAtividades?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowGUTAtividades: React.FC<GUTAtividadesWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <GUTAtividadesWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedGUTAtividades={GUTAtividadesEmpty()}>
        </GUTAtividadesWindow>
    )
};

export default GUTAtividadesWindow;
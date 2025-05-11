import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import GUTAtividadesMatrizInc from "../Inc/GUTAtividadesMatriz";
import { IGUTAtividadesMatriz } from "../../Interfaces/interface.GUTAtividadesMatriz";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { GUTAtividadesMatrizEmpty } from "@/app/GerAdv_TS/Models/GUTAtividadesMatriz";
import { useWindow } from "@/app/hooks/useWindows";

interface GUTAtividadesMatrizWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedGUTAtividadesMatriz?: IGUTAtividadesMatriz;
    onSuccess: () => void;
    onError: () => void;
}

const GUTAtividadesMatrizWindow: React.FC<GUTAtividadesMatrizWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedGUTAtividadesMatriz,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/gutatividadesmatriz/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedGUTAtividadesMatriz?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedGUTAtividadesMatriz]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedGUTAtividadesMatriz?.id ?? 0).toString()}
                >
                    <GUTAtividadesMatrizInc
                        id={selectedGUTAtividadesMatriz?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowGUTAtividadesMatriz: React.FC<GUTAtividadesMatrizWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <GUTAtividadesMatrizWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedGUTAtividadesMatriz={GUTAtividadesMatrizEmpty()}>
        </GUTAtividadesMatrizWindow>
    )
};

export default GUTAtividadesMatrizWindow;
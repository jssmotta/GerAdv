import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import AtividadesInc from "../Inc/Atividades";
import { IAtividades } from "../../Interfaces/interface.Atividades";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { AtividadesEmpty } from "@/app/GerAdv_TS/Models/Atividades";
import { useWindow } from "@/app/hooks/useWindows";

interface AtividadesWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedAtividades?: IAtividades;
    onSuccess: () => void;
    onError: () => void;
}

const AtividadesWindow: React.FC<AtividadesWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedAtividades,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/atividades/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedAtividades?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedAtividades]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedAtividades?.id ?? 0).toString()}
                >
                    <AtividadesInc
                        id={selectedAtividades?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowAtividades: React.FC<AtividadesWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <AtividadesWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedAtividades={AtividadesEmpty()}>
        </AtividadesWindow>
    )
};

export default AtividadesWindow;
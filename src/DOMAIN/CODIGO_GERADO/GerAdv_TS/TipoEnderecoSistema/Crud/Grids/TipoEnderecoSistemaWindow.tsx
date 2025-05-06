import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import TipoEnderecoSistemaInc from "../Inc/TipoEnderecoSistema";
import { ITipoEnderecoSistema } from "../../Interfaces/interface.TipoEnderecoSistema";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { TipoEnderecoSistemaEmpty } from "@/app/GerAdv_TS/Models/TipoEnderecoSistema";
import { useWindow } from "@/app/hooks/useWindows";

interface TipoEnderecoSistemaWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedTipoEnderecoSistema?: ITipoEnderecoSistema;
    onSuccess: () => void;
    onError: () => void;
}

const TipoEnderecoSistemaWindow: React.FC<TipoEnderecoSistemaWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedTipoEnderecoSistema,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/tipoenderecosistema/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedTipoEnderecoSistema?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedTipoEnderecoSistema]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedTipoEnderecoSistema?.id ?? 0).toString()}
                >
                    <TipoEnderecoSistemaInc
                        id={selectedTipoEnderecoSistema?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowTipoEnderecoSistema: React.FC<TipoEnderecoSistemaWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <TipoEnderecoSistemaWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedTipoEnderecoSistema={TipoEnderecoSistemaEmpty()}>
        </TipoEnderecoSistemaWindow>
    )
};

export default TipoEnderecoSistemaWindow;
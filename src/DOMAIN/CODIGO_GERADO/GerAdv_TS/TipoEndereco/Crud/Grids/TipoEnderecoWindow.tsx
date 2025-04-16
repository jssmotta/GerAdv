import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import TipoEnderecoInc from "../Inc/TipoEndereco";
import { ITipoEndereco } from "../../Interfaces/interface.TipoEndereco";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { TipoEnderecoEmpty } from "@/app/GerAdv_TS/Models/TipoEndereco";
import { useWindow } from "@/app/hooks/useWindows";

interface TipoEnderecoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedTipoEndereco?: ITipoEndereco;
    onSuccess: () => void;
    onError: () => void;
}

const TipoEnderecoWindow: React.FC<TipoEnderecoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedTipoEndereco,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/tipoendereco/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedTipoEndereco?.id}`);
        }

    }, [isMobile, router, selectedTipoEndereco]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedTipoEndereco?.id ?? 0).toString()}
                >
                    <TipoEnderecoInc
                        id={selectedTipoEndereco?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowTipoEndereco: React.FC<TipoEnderecoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <TipoEnderecoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedTipoEndereco={TipoEnderecoEmpty()}>
        </TipoEnderecoWindow>
    )
};

export default TipoEnderecoWindow;
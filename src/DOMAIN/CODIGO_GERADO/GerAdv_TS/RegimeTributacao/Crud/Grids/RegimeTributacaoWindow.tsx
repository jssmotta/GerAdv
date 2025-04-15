import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import RegimeTributacaoInc from "../Inc/RegimeTributacao";
import { IRegimeTributacao } from "../../Interfaces/interface.RegimeTributacao";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { RegimeTributacaoEmpty } from "@/app/GerAdv_TS/Models/RegimeTributacao";
import { useWindow } from "@/app/hooks/useWindows";

interface RegimeTributacaoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedRegimeTributacao?: IRegimeTributacao;
    onSuccess: () => void;
    onError: () => void;
}

const RegimeTributacaoWindow: React.FC<RegimeTributacaoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedRegimeTributacao,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/regimetributacao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedRegimeTributacao?.id}`);
        }

    }, [isMobile, router, selectedRegimeTributacao]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedRegimeTributacao?.id ?? 0).toString()}
                >
                    <RegimeTributacaoInc
                        id={selectedRegimeTributacao?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowRegimeTributacao: React.FC<RegimeTributacaoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <RegimeTributacaoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedRegimeTributacao={RegimeTributacaoEmpty()}>
        </RegimeTributacaoWindow>
    )
};

export default RegimeTributacaoWindow;
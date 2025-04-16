import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import FuncaoInc from "../Inc/Funcao";
import { IFuncao } from "../../Interfaces/interface.Funcao";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { FuncaoEmpty } from "@/app/GerAdv_TS/Models/Funcao";
import { useWindow } from "@/app/hooks/useWindows";

interface FuncaoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedFuncao?: IFuncao;
    onSuccess: () => void;
    onError: () => void;
}

const FuncaoWindow: React.FC<FuncaoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedFuncao,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/funcao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedFuncao?.id}`);
        }

    }, [isMobile, router, selectedFuncao]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedFuncao?.id ?? 0).toString()}
                >
                    <FuncaoInc
                        id={selectedFuncao?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowFuncao: React.FC<FuncaoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <FuncaoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedFuncao={FuncaoEmpty()}>
        </FuncaoWindow>
    )
};

export default FuncaoWindow;
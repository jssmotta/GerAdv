import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import ReuniaoPessoasInc from "../Inc/ReuniaoPessoas";
import { IReuniaoPessoas } from "../../Interfaces/interface.ReuniaoPessoas";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ReuniaoPessoasEmpty } from "@/app/GerAdv_TS/Models/ReuniaoPessoas";
import { useWindow } from "@/app/hooks/useWindows";

interface ReuniaoPessoasWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedReuniaoPessoas?: IReuniaoPessoas;
    onSuccess: () => void;
    onError: () => void;
}

const ReuniaoPessoasWindow: React.FC<ReuniaoPessoasWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedReuniaoPessoas,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/reuniaopessoas/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedReuniaoPessoas?.id}`);
        }

    }, [isMobile, router, selectedReuniaoPessoas]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedReuniaoPessoas?.id ?? 0).toString()}
                >
                    <ReuniaoPessoasInc
                        id={selectedReuniaoPessoas?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowReuniaoPessoas: React.FC<ReuniaoPessoasWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ReuniaoPessoasWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedReuniaoPessoas={ReuniaoPessoasEmpty()}>
        </ReuniaoPessoasWindow>
    )
};

export default ReuniaoPessoasWindow;
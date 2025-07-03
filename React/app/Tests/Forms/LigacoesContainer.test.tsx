import React from 'react';
import { render } from '@testing-library/react';
import LigacoesIncContainer from '@/app/GerAdv_TS/Ligacoes/Components/LigacoesIncContainer';
// LigacoesIncContainer.test.tsx
// Mock do LigacoesInc
jest.mock('@/app/GerAdv_TS/Ligacoes/Crud/Inc/Ligacoes', () => (props: any) => (
<div data-testid='ligacoes-inc-mock' {...props} />
));
describe('LigacoesIncContainer', () => {
  it('deve renderizar LigacoesInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <LigacoesIncContainer id={id} navigator={mockNavigator} />
  );
  const ligacoesInc = getByTestId('ligacoes-inc-mock');
  expect(ligacoesInc).toBeInTheDocument();
  expect(ligacoesInc.getAttribute('id')).toBe(id.toString());

});
});
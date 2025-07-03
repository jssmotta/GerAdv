import React from 'react';
import { render } from '@testing-library/react';
import AcaoIncContainer from '@/app/GerAdv_TS/Acao/Components/AcaoIncContainer';
// AcaoIncContainer.test.tsx
// Mock do AcaoInc
jest.mock('@/app/GerAdv_TS/Acao/Crud/Inc/Acao', () => (props: any) => (
<div data-testid='acao-inc-mock' {...props} />
));
describe('AcaoIncContainer', () => {
  it('deve renderizar AcaoInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <AcaoIncContainer id={id} navigator={mockNavigator} />
  );
  const acaoInc = getByTestId('acao-inc-mock');
  expect(acaoInc).toBeInTheDocument();
  expect(acaoInc.getAttribute('id')).toBe(id.toString());

});
});
import React from 'react';
import { render } from '@testing-library/react';
import ProValoresIncContainer from '@/app/GerAdv_TS/ProValores/Components/ProValoresIncContainer';
// ProValoresIncContainer.test.tsx
// Mock do ProValoresInc
jest.mock('@/app/GerAdv_TS/ProValores/Crud/Inc/ProValores', () => (props: any) => (
<div data-testid='provalores-inc-mock' {...props} />
));
describe('ProValoresIncContainer', () => {
  it('deve renderizar ProValoresInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <ProValoresIncContainer id={id} navigator={mockNavigator} />
  );
  const provaloresInc = getByTestId('provalores-inc-mock');
  expect(provaloresInc).toBeInTheDocument();
  expect(provaloresInc.getAttribute('id')).toBe(id.toString());

});
});